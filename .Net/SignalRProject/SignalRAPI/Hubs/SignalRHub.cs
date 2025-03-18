using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Runtime.CompilerServices;

namespace SignalRAPI.Hubs
{
    public class SignalRHub:Hub
    {

        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IMoneyCaseService moneyCaseService;
        private readonly IBookingService bookingService;
        private readonly INotificationService notificationService;
        private readonly IMenuTableService menuTableService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IBookingService bookingService, INotificationService notificationService, IMenuTableService menuTableService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.orderService = orderService;
            this.moneyCaseService = moneyCaseService;
            this.bookingService = bookingService;
            this.notificationService = notificationService;
            this.menuTableService = menuTableService;
        }
        public static int clientCount { get; set; }
        public async Task SendStatistik()
        {
            var values = categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", values);
            var values2 = productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", values2);
            var values3 = categoryService.TActiveCategoryCount();
            var values4 = categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", values3);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", values4);

            var value5 = productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveTProductCountByCategoryNameDrink", value6);

            var value7 = productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00")+"TL");


            var value8 = productService.TProductPriceByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductPriceByMaxPrice", value8);

            var value9 = productService.TProductPriceByMinPrice();
            await Clients.All.SendAsync("ReceiveProductPriceByMinPrice", value9);


            //var value10 = productService.TProductPriceByHamburger();
            //await Clients.All.SendAsync("ReceiveProductPriceByHamburger", value10.ToString("0.00") + "TL");

            var value11 = orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13);

            var value14 = moneyCaseService.TTotalMoneyCaseAmouny();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14);


            //var value16 = _menuTableService.TMenuTableCount();
            //await Clients.All.SendAsync("ReceiveMenuTableCount", value16);

        }
      
        public async Task SendProgress()
        {
            var values = moneyCaseService.TTotalMoneyCaseAmouny();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", values.ToString("0.00") + "TL");

            var value2 = orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);
            //var value16 = _menuTableService.TMenuTableCount();
            //await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
            var value5 = productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

            //var value6 = productService.TProductPriceByHamburger();
            //await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6);

            var value7 = productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

            var value8 = orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            //var value9 = productService.TProductPriceByHamburger();
            //await Clients.All.SendAsync("ReceiveProductPriceBySteakBurger", value9);

            var value10 = productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value10);


        }
        public async Task GetBookingList()
        {
            var value2 = bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveGetListAll", value2);
        }
        public async Task SendNotification()
        {
            var value2 = notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", value2);

            var notificationByFalse = notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveGetAllNotificationByFalse", notificationByFalse);


        }

        public async Task GetMenuTableStatus()
        {
            var value = menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveCleintCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveCleintCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
