namespace Synthesis
{
    using System;
    using System.Linq;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal sealed class Rewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        { 
            var identifierToken = node.Identifier.ToString();

            var leadingTrivia = node.GetLeadingTrivia();

            var obsoleteExpression =

                        SyntaxFactory.AttributeList
                        (
                            SyntaxFactory.SingletonSeparatedList<AttributeSyntax>
                            (
                                SyntaxFactory.Attribute
                                (
                                    SyntaxFactory.IdentifierName("Obsolete")
                                )
                                .WithArgumentList
                                (
                                    SyntaxFactory.AttributeArgumentList
                                    (
                                        SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>
                                        (
                                            SyntaxFactory.AttributeArgument
                                            (
                                                SyntaxFactory.LiteralExpression
                                                (
                                                    SyntaxKind.StringLiteralExpression,
                                                    SyntaxFactory.Literal("Use " + identifierToken[0].ToString().ToUpper() + identifierToken.Substring(1) + " instead")
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        ).WithLeadingTrivia(leadingTrivia);

            //char.IsLower(identifierToken[0])
            if (identifierToken[0] >= 'a' && identifierToken[0] <= 'z') {
                //identifierToken[0].ToString().ToUpper();


                /*  var obsoleteExpression = 
                      SyntaxFactory.AttributeList(
                          SyntaxFactory.Attribute(
                              SyntaxFactory.IdentifierName("Obsolete").WithLeadingTrivia(leadingTrivia)), 
                              SyntaxFactory.AttributeArgumentList(
                                  SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>(
                                      SyntaxFactory.AttributeArgument(
                                          SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(node.Identifier)                      


                  ))))); */
                  
                node = node.AddAttributeLists(obsoleteExpression);

            }
            
            return base.VisitClassDeclaration(node);
        }
        
    }
}
