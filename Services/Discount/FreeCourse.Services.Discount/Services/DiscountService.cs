using Dapper;
using FreeCourse.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnetion;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnetion = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnetion.ExecuteAsync("delete from discount where id=@Id", new { Id = id });

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("discount not found", 404);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discount = await _dbConnetion.QueryAsync<Models.Discount>("Select * From discount");
            return Response<List<Models.Discount>>.Success(discount.ToList(), 200);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnetion.QueryAsync<Models.Discount>("select * from discount where userid=@UserId and code=@Code",
                new { UserId = userId, Code = code });

            var hasDiscount = discounts.FirstOrDefault();

            if (hasDiscount == null)
            {
                return Response<Models.Discount>.Fail("Discount bot found", 404);
            }

            return Response<Models.Discount>.Success(hasDiscount, 200);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnetion.QueryAsync<Models.Discount>("select * from discount where id=@Id", new { Id = id }))
                .SingleOrDefault();

            if (discount == null)
                return Response<Models.Discount>.Fail("Discount not found", 404);

            return Response<Models.Discount>.Success(discount, 200);


        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStatus = await _dbConnetion.ExecuteAsync("Insert Into discount (userid,rate,code) Values(@UserId,@Rate,@Code)", discount);

            if (saveStatus > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("an error accured while adding", 500);

        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnetion.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id",
                new { Id = discount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("discount not found", 404);
        }
    }
}
