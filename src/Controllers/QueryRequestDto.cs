namespace Controllers;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared;

public sealed class QueryRequestDto
{
    /// <example>https://service.company.com/tenant1/resource/_PzMFA-0euRFGdaqlbGTDxT</example>>
    [BindRequired]
    public ResourceUrl Resource { get; set; }
}