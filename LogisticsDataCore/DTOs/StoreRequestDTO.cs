namespace LogisticsDataCore.DTOs
{
    public record StoreRequestDTO(
        int StoreID,
        string StoreName,
        string StoreCityLocation,
        string StoreDescription,
        string StoreGovernorateName,
        string StoreManagerName
    );
}
