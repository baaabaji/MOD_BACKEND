using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD_DATA;
using MOD_BLO;
using NUnit;
using NUnit.Framework;

namespace MOD_TEST
{
    [TestFixture]
    public class TestingULogic
    {
        [Test]
        public void getAllUser()
        {
            ULogic uLogic = new ULogic();
            IList<usign> user = uLogic.GetAllUsers();
            Assert.IsNotNull(user);


            //mjbjafjadfjdfdjfadjfadjkffdjajkfafafdjkfdadkfkadfkadfkadjfkadfkajka
        }
    }
}
