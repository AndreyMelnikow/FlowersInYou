using FlowersInYou.Controllers;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersInYou.Tests.Tests
{
    public class MaterialsControllerTests
    {
        private IMaterialService _materialService = new MaterialService(
            new MaterialRepository(new FlowersInYouContext()));

        [Fact]
        public void GetMaterialListTest()
        {
            var controller = new MaterialsController(_materialService);

            var result = controller.GetMaterialsList().Value as IEnumerable<Material>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Material>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetMaterialTest()
        {
            var controller = new MaterialsController(_materialService);

            var result = controller.GetMaterial(2).Value as Material;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Material>(result);
            Assert.Equal(result, model);
        }
    }
}
