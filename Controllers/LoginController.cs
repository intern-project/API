using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using API.Models;


namespace TimeManagment.Controllers
{
    
    [Route("api/login")]
    

    [ApiController]
   // [EnableCors("MyCorsPolicy")]

    public class LoginController : ControllerBase
    {
        
        private readonly LoginTypeRepository loginTypeRepository;
        public LoginController()
        {
            loginTypeRepository = new LoginTypeRepository();
        }
        // GET: api/Login
        [HttpGet]
        public IEnumerable<IEmployee> Get()
        {
            return this.loginTypeRepository.getA();
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Login
        [HttpPost]
        public IToken Post([FromBody] IUser user)
        {

           IEmployee existingUser = loginTypeRepository.login(user);

            if (existingUser != null)
            {
                //Set the token values
                string setRole = existingUser.role;

                //security key
                string securityKey = "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";
                //symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

                //signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                //add claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, setRole)); //getting from db
                claims.Add(new Claim("Our_Custom_Claim", "Our custom value"));
                claims.Add(new Claim("Id", "110"));


                //create token
                var token = new JwtSecurityToken(
                        issuer: "smesk.in",
                        audience: "readers",
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials
                        , claims: claims
                    );

                //return token
                IToken tokenToFront = new IToken();

                tokenToFront.token = new JwtSecurityTokenHandler().WriteToken(token);
                tokenToFront.role = setRole;

                return tokenToFront;

            }
            else
            {
                IToken tokenToFront = new IToken();
                tokenToFront.token = "";
                tokenToFront.role = "";

                return tokenToFront;
            }
    }

        // PUT: api/Login/5
        // [HttpPost]
        // public IEmployee Post([FromBody] IUser user)
        // {
        //    return loginTypeRepository.login(user);
        // }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
