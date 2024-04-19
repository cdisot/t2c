namespace CC.Core
{
    public interface ITemplateGenerator
    {
        string GenerateOutput<TModel>(TModel model, string templateContent);
        string LoadGenerateOutput<TModel>(string templatePath, TModel model);
    }
}
