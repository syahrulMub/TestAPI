using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPICustomerBusinessLogic;

public class Customer
{
    [Column("customerid")]
    public int customerId { get; set; }
    [Column("customercode")]
    public string customerCode { get; set; }
    [Column("customername")]
    public string customerName { get; set; }
    [Column("customeraddress")]
    public string customerAddress { get; set; }
    [Column("createdby")]
    public int createdBy { get; set; }
    [Column("createdat")]
    public DateTime createdAt { get; set; }
    [Column("modifiedby")]
    public int? modifiedBy { get; set; }
    [Column("modifiedat")]
    public DateTime? modifiedAt { get; set; }
}
