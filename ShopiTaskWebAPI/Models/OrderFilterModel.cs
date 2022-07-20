using MediatR;

namespace ShopiTaskWebAPI.Models
{
    public class OrderFilterModel : FilterModel, IRequest<List<Order>>
    {
        //Bir istekte kaç sonuç döndüğü

        public DateTime? StartDate { get; set; }
        //Order CreatedOn değerinin maximum olması gereken değer
        public DateTime? EndDate { get; set; }
        //Filtrelemek için alınan liste, örneğin [10,20] aldığı zaman sadece Created ve InProgress olan Order'lar dönmeli
        public List<OrderStatus> Statuses { get; set; }
        //Gelen sonuçlar hangi Order alanına göre sıralanacak (ascending olarak sıralanmalı)
        //"Id", "BrandId", "Price", "StoreName", "CustomerName", "CreatedOn", "Status" değerlerini alabilir
    }

}
