using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SharpPythonCompiler.Core
{
    class PropertyNodeFinder : ISyntaxNodeFinder
    {
        public ClassNodeFinder ClassNodeFinder { get; private set; }

        public string Name { get; private set; }

        public PropertyNodeFinder(ClassNodeFinder classNodeFinder, string name)
        {
            ClassNodeFinder = classNodeFinder;
            Name = name;
        }

        public CSharpSyntaxNode Find(CSharpSyntaxNode root)
        {
            return (ClassNodeFinder.Find(root) as ClassDeclarationSyntax).Members
                .OfType<PropertyDeclarationSyntax>()
                .FirstOrDefault(n => n.Identifier.Text == Name);
        }
    }
}