using System;
using System.Reflection;

namespace WebAPIAngularJsFileSystem.WebUI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}