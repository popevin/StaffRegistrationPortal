using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using StaffRegistrationPortal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using StaffRegistrationPortal.DTOs;

namespace StaffRegistrationPortal.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private IConfiguration _config;

        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }
      
       public string GenerateToken(LogViewModel logdata)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

           
            claims.Add(new Claim(ClaimTypes.Email, logdata.Email));

            claims.Add(new Claim(ClaimTypes.Name, logdata.FirstName));

            claims.Add(new Claim(ClaimTypes.GivenName, logdata.LastName));

            claims.Add(new Claim(ClaimTypes.Role, logdata.RoleId.ToString()));

            claims.Add(new Claim(ClaimTypes.GroupSid, logdata.DepartmentId.ToString()));




            //claims.Add(new Claim(ClaimTypes.OtherPhone, logdata.RoleId.ToString()));



            /*  if (baseResponse.Data != null )
              {
                  string serializedData = JsonConvert.SerializeObject(baseResponse.Data);

                  claims.Add(new Claim(ClaimTypes.UserData, serializedData));
              }*/

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

            




        }



    }
}
/*  if (baseResponse.Data != null && baseResponse.Data is UserViewModel userModel)
            {
                *//*string serializedData = JsonConvert.SerializeObject(userModel);
                UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(serializedData);

                claims.Add(new Claim(ClaimTypes.UserData, user));*//*

                
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.UserId.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, userModel.RoleId.ToString()));
                claims.Add(new Claim(ClaimTypes.Gender, userModel.GenderId.ToString()));
                claims.Add(new Claim(ClaimTypes.UserData, userModel.DepartmentId.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, userModel.Email));
                claims.Add(new Claim(ClaimTypes.Name, userModel.FirstName));
                claims.Add(new Claim(ClaimTypes.Name, userModel.LastName));
                claims.Add(new Claim(ClaimTypes.Name, userModel.OtherName));
                claims.Add(new Claim(ClaimTypes.StreetAddress, userModel.Address));
                claims.Add(new Claim(ClaimTypes.MobilePhone, userModel.Phone));
                claims.Add(new Claim(ClaimTypes.UserData, userModel.IsActive.ToString()));
{
  "roleId": 1,
  "genderId": 2,
  "departmentId": 3,
  "email": "man@gmail.com",
  "password": "4544",
  "firstName": "man",
  "lastName": "ayo",
  "otherName": "jay",
  "address": "gabu street",
  "phone": "255363647"
}

            }
            if(baseResponse.Data!= null)
            {
                var xxx = baseResponse.Data.ToString();
                UserViewModel userList = JsonConvert.DeserializeObject<UserViewModel>(xxx);
                claims.Add(new Claim(ClaimTypes.UserData, userList));
            }*/
