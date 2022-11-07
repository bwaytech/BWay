using BWay.Infra.Interfaces;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class RoletaRepository : IRoletaRepository
    {
        private readonly ApiContext _context;
        private readonly IUtil _util;

        private static List<CorretorRoletaModel> roleta = new List<CorretorRoletaModel>();

        public RoletaRepository(ApiContext context, IUtil util)
        {
            _context = context;
            _util = util;
        }

        public List<CorretorRoletaModel> SalvarRoleta(List<CorretorRoletaModel> roletaModel)
        {
            var guid = _util.CriarNovoId();

            roletaModel.ForEach(corretor => {
                corretor.IdRoleta = guid;
                _context.Corretores.Add(corretor);
            });

            _context.SaveChanges();

            return roletaModel;
        }

        public List<CorretorRoletaModel> ObterRoleta(Guid id)
        {
            var retorno = _context.Corretores.Where(corretor => corretor.IdRoleta.Equals(id)).ToList();

            return retorno.OrderBy(corretor => corretor.PosicaoAtual).ToList();
        }

        public List<CorretorRoletaModel> ObterRoletaPorOperacao(int idOperacao)
        {
            var retorno = _context.Corretores.Where(corretor => corretor.IdOperacacao.Equals(idOperacao));
            return retorno.ToList();
        }

        public CorretorRoletaModel ObterCorretorSeEstiverDisponivel(Guid idRoleta, int idCorretor)
        {
            var corretor = _context.Corretores
                .Where(corretor => corretor.IdRoleta.Equals(idRoleta) && corretor.IdCorretor.Equals(idCorretor) && corretor.StatusCorretor == Enums.StatusCorretorEnum.Disponivel);

            return corretor.FirstOrDefault();
        }

        public CorretorRoletaModel ObterCorretorEmAtendimento(Guid idRoleta, int idCorretor)
        {
            var corretor = _context.Corretores
                .Where(corretor => corretor.IdRoleta.Equals(idRoleta) && corretor.IdCorretor.Equals(idCorretor) && corretor.StatusCorretor == Enums.StatusCorretorEnum.EmAtendimento);

            return corretor.FirstOrDefault();
        }

        public CorretorRoletaModel ObterCorretorEmPausa(Guid idRoleta, int idCorretor)
        {
            var corretor = _context.Corretores
                .Where(corretor => corretor.IdRoleta.Equals(idRoleta) && corretor.IdCorretor.Equals(idCorretor) && corretor.StatusCorretor == Enums.StatusCorretorEnum.EmPausa);

            return corretor.FirstOrDefault();
        }

        public void AtualizarRoleta(List<CorretorRoletaModel> roletaModel)
        {
            Guid idRoleta = roletaModel[0].IdRoleta;

            var roletaOld = ObterRoleta(idRoleta);

            roletaOld.ForEach(corretor => {
                roletaModel.ForEach(corretorNovo => {
                    if (corretorNovo.IdCorretor == corretor.IdCorretor)
                    {
                        corretor.Ordem = corretorNovo.Ordem;
                        corretor.PosicaoAtual = corretorNovo.PosicaoAtual;
                        corretor.UltimoAtendimento = corretorNovo.UltimoAtendimento;
                        corretor.StatusCorretor = corretorNovo.StatusCorretor;
                    }
                });
            });

            _context.Corretores.UpdateRange(roletaOld);
            _context.SaveChanges();
        }

        public void AtualizarRoleta(CorretorRoletaModel corretor)
        {
            var corretorAlterado = _context.Corretores.Where(c => c.IdRoleta.Equals(corretor.IdRoleta) && c.IdCorretor.Equals(corretor.IdCorretor)).First();
            corretorAlterado.StatusCorretor = corretor.StatusCorretor;

            _context.Corretores.Update(corretorAlterado);
            _context.SaveChanges();
        }
    }
}
