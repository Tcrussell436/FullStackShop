namespace FullStackShop.API.Controllers.DTO;

public record UserInfoDTO
{
    public string id { get; set; }
    public string email { get; set; }
    public DateTime created { get; set; }
}