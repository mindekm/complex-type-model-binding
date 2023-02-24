using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared;

public sealed class BinderProvider : IModelBinderProvider
{
    private readonly Dictionary<Type, IModelBinder> binders = new Dictionary<Type, IModelBinder>
    {
        [typeof(ResourceUrl)] = new ResourceUrlBinder(),
    };

    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        return binders.TryGetValue(context.Metadata.ModelType, out var binder) ? binder : null;
    }
}