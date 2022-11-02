using Microsoft.AspNetCore.Mvc;

namespace NotifyMeCRUD.Controllers;

public class CustomErrorsController : ApiController{
    [Route("/error")]
    public IActionResult Error(){
        return Problem();
    }
}