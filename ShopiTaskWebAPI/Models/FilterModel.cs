namespace ShopiTaskWebAPI.Models
{
    public class FilterModel
    {
        //Bir istekte kaç sonuç döndüğü
        public int PageSize { get; set; } = 10;
        //Kaçıncı sayfanın döndüğü (Örneğin PageNumber=2, PageSize=25 iken 26-50 arasındaki sonuçları dönmeli)
        public int PageNumber { get; set; } = 1;
        //Arama metni, StoreName ve CustomerName değerleri üzerinde arama yapılabiliyor olmalı
        public string SearchText { get; set; }
        //Order CreatedOn değerinin minimum olması gereken değer

        //"Id", "BrandId", "Price", "StoreName", "CustomerName", "CreatedOn", "Status" değerlerini alabilir
        public string SortBy { get; set; }
    }

}
