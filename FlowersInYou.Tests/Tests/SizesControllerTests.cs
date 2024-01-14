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
    public class SizesControllerTests
    {
        private ISizeService _sizeService = new SizeService(
            new SizeRepository(new FlowersInYouContext()));

        [Fact]
        public void GetSizesListTest()
        {
            var controller = new SizesController(_sizeService);

            var result = controller.GetSizesList().Value as IEnumerable<Size>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Size>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetSizeTest()
        {
            var controller = new SizesController(_sizeService);

            var result = controller.GetSize(2).Value as Size;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Size>(result);
            Assert.Equal(result, model);
        }
    }
}
