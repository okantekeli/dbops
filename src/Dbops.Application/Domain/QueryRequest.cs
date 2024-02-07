using System.ComponentModel.DataAnnotations;

namespace Dbops.Application.Domain;

public class QueryRequest 
{
    [Required]
    [Display(Name = "Request Id")]
    public int RequestId {get;set;}

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Content")]
    public string Content {get;set;} = string.Empty;
    public QueryRequest()
    {
    }
}