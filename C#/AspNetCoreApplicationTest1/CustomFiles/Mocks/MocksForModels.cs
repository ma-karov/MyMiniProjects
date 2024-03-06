
namespace AspNetCoreApplicationTest1.CustomFiles.MocksController 
{
    public class MocksForModels {} 

    public class MockGetListCarsModel : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsModel 
    {
        private readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel GetListCarsCategoriesModel = new AspNetCoreApplicationTest1.CustomFiles.MocksController.MockGetListCarsCategoriesModel();

        public IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> AllCars() =>
            new List<AspNetCoreApplicationTest1.CustomFiles.Models.Cars>() {
                new AspNetCoreApplicationTest1.CustomFiles.Models.Cars { Name = "Zhiguli", Description = "", Price = 12150, CarCategory = GetListCarsCategoriesModel.AllCategories().First() },
                new AspNetCoreApplicationTest1.CustomFiles.Models.Cars { Name = "Tesla", Description = "", Price = 3010, CarCategory = GetListCarsCategoriesModel.AllCategories().Last() } };

        public void AllCarsToStringJSON(){}
    }

    public class MockGetListCarsCategoriesModel : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel 
    {
        public IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> AllCategories() =>
            new List<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> {
                new AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories { Name = "Simple", Description = "Description1" },
                new AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories { Name = "Electro", Description = "Description2" } };

    }
}
