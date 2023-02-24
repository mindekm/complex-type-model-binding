namespace Controllers;

using Shared;

public sealed class ResponseDto
{
    public ResourceUrl Resource { get; set; }

    public string Server { get; set; }

    public string Tenant { get; set; }

    public string Identifier { get; set; }
}