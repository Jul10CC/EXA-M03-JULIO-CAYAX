using System;
using System.Reflection;

namespace EXA_M03_JULIO_CAYAX.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}