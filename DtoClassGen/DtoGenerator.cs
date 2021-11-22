using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using System.Linq;
using System.Text;

namespace DtoClassGen
{
    [Generator]
    public class DtoGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {

            var synatxTrees = context.Compilation.SyntaxTrees;

            foreach (var sytaxTree in synatxTrees)
            {
                var mappableTypeDeclarations = sytaxTree.GetRoot().DescendantNodes().OfType<TypeDeclarationSyntax>()
                    .Where(x => x.AttributeLists.Any(y => y.ToString().StartsWith("[MapModel]"))).ToList();

                foreach (var mappableTypeDeclaration in mappableTypeDeclarations)
                {
                    var usingDirectives = sytaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>();
                    var usingDirectivesAsText = string.Join("\r\n", usingDirectives);
                    var sourceBuilder = new StringBuilder(usingDirectivesAsText);

                    var className = mappableTypeDeclaration.Identifier.ToString();
                    var genClassName = $"{className}Dto";

                    var ignoreProperties = mappableTypeDeclaration.ChildNodes()
                        .Where(x => x is PropertyDeclarationSyntax pdc &&
                        pdc.AttributeLists.Any(y => y.ToString().StartsWith("[MapModelIgnore]")));

                   
                    var newmappableTypeDeclaration = mappableTypeDeclaration.RemoveNodes(ignoreProperties, SyntaxRemoveOptions.KeepEndOfLine);

                    var spliClass = newmappableTypeDeclaration.ToString().Split(new[] { '{' }, 2);

                    sourceBuilder.Append($@"
namespace GeneratedMappers
{{
    public class {genClassName}
    {{
");

                    sourceBuilder.AppendLine(spliClass[1].Replace(className, genClassName));
                    sourceBuilder.AppendLine("}");


                    //context.AddSource($"{className}Dto", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));

                    // Write the generated source to a file
                    string path = @"D:\Projects\POC\SourceGenAPI\WebAPI\Generated\";
                    Directory.CreateDirectory(path);
                    File.WriteAllText($"{path}{genClassName}.cs", sourceBuilder.ToString());

                }

            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();
            //}
#endif
        }
    }
}
