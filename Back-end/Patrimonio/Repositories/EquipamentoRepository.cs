using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Patrimonio.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {

        private readonly PatrimonioContext ctx;

        public EquipamentoRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Equipamento Alterar(Equipamento equipamento)
        {
            ctx.Entry(equipamento).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return equipamento;
        }

        public Equipamento Cadastrar(Equipamento equipamento)
        {
            ctx.Equipamentos.Add(equipamento);
            ctx.SaveChanges();

            return equipamento;
        }

        public void Excluir(Equipamento equipamento)
        {
            ctx.Equipamentos.Remove(equipamento);
            ctx.SaveChangesAsync();
        }

        Equipamento IEquipamentoRepository.BuscarPorID(int id)
        {
            return ctx.Equipamentos.Find(id);
        }

        List<Equipamento> IEquipamentoRepository.Listar()
        {
            return ctx.Equipamentos.ToList();
        }
    }
}
