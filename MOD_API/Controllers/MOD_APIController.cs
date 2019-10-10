using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MOD_DATA;
using MOD_BLO;


namespace MOD_API.Controllers
{
    public class MOD_APIController : ApiController
    {

        MOD_BLO.ULogic UL = new MOD_BLO.ULogic();



        [Route("api/GetAllUser")]
        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            var resut= UL.GetAllUsers();
            return Ok(resut);
        }
        [Route("api/getuserbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var result = UL.GetUserById(id);
            return Ok(result);
        }

        [Route("api/blockuser/{id}")]
        [HttpGet]
        public IHttpActionResult BlockUser(int id)
        {
            UL.BlockUser(id);
            return Ok("User Blocked");

        }

        [Route("api/unblockuser/{id}")]
        [HttpGet]
        public IHttpActionResult UnblockUser(int id)
        {
            UL.UnBlockUser(id);
            return Ok("User Unblocked");
        }

    

        [Route("api/login")]
        [HttpGet]
        public IHttpActionResult loginData(string email, string password)
        {
            usign result = UL.login(email, password);
            return Ok(result);
        }


        [Route("api/register")]
        [HttpPost]
        public IHttpActionResult Register(usign User)
        {
            UL.Register(User);
            return Ok("User Added");
        }

        

    

        //Skill Logic


        [Route("api/getAllSkills")]
        [HttpGet]
        public IHttpActionResult GetSkills()
        {
            var result = UL.GetAllSkills();
            return Ok(result);
        }

        [Route("api/getskillprice/{id}")]
        [HttpGet]
        public IHttpActionResult GetSkillPrice(string id)
        {
            var result = UL.GetSkillsPrice(id);
            return Ok(result);
        }


        [Route("api/addskill")]
        [HttpPost]
        public IHttpActionResult AddSkill(SkillDtl skillDtl)
        {
            UL.AddNewSkill(skillDtl);
            return Ok("Request Sent");
        }

        [Route("api/delteteskill/{id}")]

        [HttpGet]
        public IHttpActionResult DeleteSkill(int id)
        {
            UL.DeleteSkill(id);
            return Ok("Deleted");
        }

        [Route("api/getskillbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetSkillById(int id)
        {
            var result = UL.GetSkillById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Empty");
            }
        }


        [Route("api/searchtrainings/{id}")]
        [HttpGet]
        public IHttpActionResult SearchTrainings(string id)
        {
            var result = UL.Search(id);
            return Ok(result);

        }

        [Route("api/addTraining")]
        [HttpPost]

        public IHttpActionResult TrainingData(TrainingDtl trainingDtl)
        {
            UL.addTrainingDtls(trainingDtl);
            return Ok("Sent");
        }

        //Get training Data
        [Route("api/getapprovals")]
        [HttpGet]
        public IHttpActionResult Approvals()
        {
            var result = UL.GetApproval();
            return Ok(result);
        }

        [Route("api/approveTraining/{id}")]
        [HttpGet]

        public IHttpActionResult approve(int id)
        {
            UL.Approve(id);
            return Ok("Training Approved");
        }

        [Route("api/declinedTraining/{id}")]
        [HttpGet]
        public IHttpActionResult declined(int id)
        {
            UL.Declined(id);
            return Ok("Training Rejected");
        }

        //Get trainingById
        [Route("api/trainingById/{id}")]
        [HttpGet]

        public IHttpActionResult GetTrainingById(int id)
        {
            var result = UL.TrainingById(id);
            return Ok(result);
        }

        //Payment
        [Route("api/paymentgate")]
        [HttpPost]
        public IHttpActionResult PayTrainingFee(PaymentDtl paymentDtl)
        {
            UL.addPayment(paymentDtl);
            return Ok("Fee Paid");
        }

        [Route("api/allpayments")]
        [HttpGet]
        public IHttpActionResult GetPayments()
        {
            var result = UL.GetAllPayment();
            return Ok(result);
        }

        [Route("api/updatepay/{id}")]
        [HttpGet]
        public IHttpActionResult updatePay(int id)
        {
            UL.PayUpdate(id);
            return Ok("Payment Confirmed");
        }

        [Route("api/updateProgress")]
        [HttpPost]
        public IHttpActionResult Progress(TrainingDtl proData)
        {
            UL.UpdateProg(proData);
            return Ok("Progress Updated");

        }

        //AdminCommision
        [Route("api/admincommision")]
        [HttpPost]
        public IHttpActionResult Commision(PaymentDtl paymentDtl)
        {
            UL.AdminCommision(paymentDtl);
            return Ok("Updated");
        }

        //Update Trainer Profile
        [Route("api/updatetrainerprofile")]
        [HttpPost]
        public IHttpActionResult UpdateProfile(usign userDtl)
        {
            UL.UpdateProfile(userDtl);
            return Ok("Updated");
        }



    }
}

