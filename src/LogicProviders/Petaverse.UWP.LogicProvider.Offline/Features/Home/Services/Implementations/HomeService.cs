using Petaverse.UWP.Core;
using System;
using System.Collections.Generic;

namespace Petaverse.UWP.LogicProvider.Offline;

public class HomeService : IHomeService
{
    #region [ CTors ]

    public HomeService()
    {

    }

    #endregion

    #region [ Methods ]

    public Task<IEnumerable<FosterCenter>> GetFosterCentersAsync()
    {
        return Task.FromResult<IEnumerable<FosterCenter>>(new List<FosterCenter>()
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Petaverse Foster Center",
                Address = "Quận 9 | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/StoreLogo.png",
                Rating = 5,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = true
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Baby Foster",
                Address = "Quận 3 | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo1.jpg",
                Rating = 3.9f,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = false
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Square Space",
                Address = "Quận 3 | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo2.jpeg",
                Rating = 4.6,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = false
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Eagle Eyes",
                Address = "Bình Thạnh | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo3.jpeg",
                Rating = 3.7f,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = true
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "The Cat Company",
                Address = "Thủ Đức | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo4.jpeg",
                Rating = 5,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = false
            }
            ,
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CatnMouse",
                Address = "Thủ Đức | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo5.jpeg",
                Rating = 5,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = true
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Friendly Pets",
                Address = "Nguyễn Văn Cừ | Quy Nhơn",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo5.jpeg",
                Rating = 4.9,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = false
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "QMO",
                Address = "Thủ Đức | Hồ Chí Minh",
                Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo4.jpeg",
                Rating = 5,
                CreatedOn = new DateTime(2019, 10, 12),
                IsUserFollowing = true
            }
        });
    }

    public Task<IEnumerable<Event>> GetTopEventsAsync()
    {
        return Task.FromResult<IEnumerable<Event>>(new List<Event>()
        {
            new Event
            {
                Title = "Góc hy vọng",
                DominantColor = "#ead6be",
                Description = "Góc hy vọng là một sự kiện được tổ chức hàng năm nhằm mục đích gây quỹ cho các trung tâm nuôi dưỡng thú cưng.",
                Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo1.jpg",
                DateTime = new DateTime(2021, 10, 12),
            },
            new Event
            {
                Title = "Cách sống chung với thú cưng",
                DominantColor = "#52636b",
                Description = "Hạn chế tổn thất đồ dùng trong nhà với các kỹ năng nuôi con siêu hiệu quả.",
                Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo2.jpg",
                DateTime = new DateTime(2021, 10, 12),
            },
            new Event
            {
                Title = "Cách nuôi dưỡng thú cưng",
                DominantColor = "#94cfd5",
                Description = "Tìm hiểu bệnh tật, chất dinh dưỡng và quan sát mèo.",
                Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo3.jpeg",
                DateTime = new DateTime(2021, 10, 12),
            },
            new Event
            {
                Title = "Những điều lưu khi nhận mèo con",
                DominantColor = "#543930",
                Description = "Học những phương pháp nuôi mèo con cho mèo mau lớn và mạnh khỏe.",
                Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo4.jpg",
                DateTime = new DateTime(2021, 10, 12),
            },
        });
    }
    #endregion
}
