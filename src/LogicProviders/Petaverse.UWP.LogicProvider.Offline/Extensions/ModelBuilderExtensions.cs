using Microsoft.EntityFrameworkCore;

namespace Petaverse.UWP.LogicProvider.Offline;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {

        #region [ Carousel ]

        InsertCarousels(modelBuilder);
        #endregion

        #region [ Foster Centers ]

        InsertTopFosterCenters(modelBuilder);
        #endregion

        #region [ Adoptions ]

        InsertNewAdoptions(modelBuilder);
        #endregion

        modelBuilder.Entity<HomePage_UrgentCases>().HasData(
                       new HomePage_UrgentCases
                       {
                           Id = Guid.NewGuid(),
                           Title = "Title 1",
                           Description = "Description 1",
                           Image = "Image 1",
                           HelpDescription = "Help Description 1",
                           Location = "Location 1",
                           EventDate = DateTime.Now
                       },
                                  new HomePage_UrgentCases
                                  {
                                      Id = Guid.NewGuid(),
                                      Title = "Title 2",
                                      Description = "Description 2",
                                      Image = "Image 2",
                                      HelpDescription = "Help Description 2",
                                      Location = "Location 2",
                                      EventDate = DateTime.Now
                                  }
                                         );

        static void InsertCarousels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomePage_Carousels>().HasData(
                                        new HomePage_Carousels
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Góc hy vọng",
                                            Description = "Góc hy vọng là một sự kiện được tổ chức hàng năm nhằm mục đích gây quỹ cho các trung tâm nuôi dưỡng thú cưng.",
                                            Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo1.jpg",
                                            DominantColor = "#ead6be",
                                            EventDate = new DateTime(2021, 10, 12)
                                        },
                                        new HomePage_Carousels
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Cách sống chung với thú cưng",
                                            Description = "Hạn chế tổn thất đồ dùng trong nhà với các kỹ năng nuôi con siêu hiệu quả.",
                                            Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo2.jpg",
                                            DominantColor = "#52636b",
                                            EventDate = new DateTime(2021, 10, 12)
                                        },
                                        new HomePage_Carousels
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Cách nuôi dưỡng thú cưng",
                                            Description = "Tìm hiểu bệnh tật, chất dinh dưỡng và quan sát mèo.",
                                            Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo3.jpeg",
                                            DominantColor = "#94cfd5",
                                            EventDate = new DateTime(2021, 10, 12)
                                        },
                                        new HomePage_Carousels
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Những điều lưu khi nhận mèo con",
                                            Description = "Học những phương pháp nuôi mèo con cho mèo mau lớn và mạnh khỏe.",
                                            Image = "ms-appx:///Assets/Mocks/HomePage/TitleDemo4.jpg",
                                            DominantColor = "#543930",
                                            EventDate = new DateTime(2021, 10, 12)
                                        });
        }

        static void InsertTopFosterCenters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomePage_TopFosterCenters>().HasData(
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Petaverse Foster Center",
                    Address = "Quận 9 | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/StoreLogo.png",
                    Rating = 5,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = true
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Baby Foster",
                    Address = "Quận 3 | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo1.jpg",
                    Rating = 3.9f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Square Space",
                    Address = "Quận 3 | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo2.jpeg",
                    Rating = 4.6f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Eagle Eyes",
                    Address = "Bình Thạnh | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo3.jpeg",
                    Rating = 3.7f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = true
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Cat Company",
                    Address = "Thủ Đức | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo4.jpeg",
                    Rating = 5f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "CatnMouse",
                    Address = "Thủ Đức | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo5.jpeg",
                    Rating = 5f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = true
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Friendly Pets",
                    Address = "Nguyễn Văn Cừ | Quy Nhơn",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo5.jpeg",
                    Rating = 4.9f,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "QMO",
                    Address = "Thủ Đức | Hồ Chí Minh",
                    Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo4.jpeg",
                    Rating = 5,
                    CreatedOn = new DateTime(2019, 10, 12),
                    IsUserFollowing = true
                });
        }

        static void InsertNewAdoptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomePage_NewAdoptions>().HasData(
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid().ToString(),
                    PetId = Guid.NewGuid().ToString(),
                    UserName = "Nguyễn Văn Khang",
                    PetName = "Jolly",
                    AdoptionState = "Nuôi không giới hạn",
                    UserImage = "User Image 1",
                    PetImage = "Pet Image 1"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = "User 2",
                    PetId = "Pet 2",
                    UserName = "User Name 2",
                    PetName = "Pet Name 2",
                    AdoptionState = "Adoption State 2",
                    UserImage = "User Image 2",
                    PetImage = "Pet Image 2"
                });
        }
    }
}
