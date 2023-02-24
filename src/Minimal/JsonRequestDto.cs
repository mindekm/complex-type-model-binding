using System.ComponentModel.DataAnnotations;
using Shared;

public sealed class JsonRequestDto
{
    /// <example>https://service.company.com/tenant1/resource/_PzMFA-0euRFGdaqlbGTDxT</example>>
    [Required]
    public ResourceUrl Resource { get; set; }
}