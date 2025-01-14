using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAPI.Models;

namespace MinhaAPI.Data.Map
{
    /** Realiza o mapeamento da entidade Usuario para se usado no contexto do banco de dados
    */
    public class LoginMap : IEntityTypeConfiguration<LoginModel>
    {
        public void Configure(EntityTypeBuilder<LoginModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(6);
        }
    }
}
