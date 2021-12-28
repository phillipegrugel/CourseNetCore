using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Helpers;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        // Aluno
        public Aluno[] GetAllAlunos(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Disciplina)
                             .ThenInclude(_ => _.Professor);
            }

            query = query.AsNoTracking().OrderBy(_ => _.Id);
            return query.ToArray();
        }
        public async Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Disciplina)
                             .ThenInclude(_ => _.Professor);
            }

            query = query.AsNoTracking().OrderBy(_ => _.Id);
            
            if (!string.IsNullOrEmpty(pageParams.Nome))
            {
                query = query.Where(aluno => aluno.Nome.ToUpper().Contains(pageParams.Nome.ToUpper())
                                             || aluno.Sobrenome.ToUpper().Contains(pageParams.Nome.ToUpper()));
            }

            if (pageParams.Matricula != null)
            {
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            }

            if (pageParams.Ativo != null)
            {
                query = query.Where(aluno => aluno.Ativo == pageParams.Ativo);
            }

            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public Aluno GetAlynoById(int alunoId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Disciplina)
                             .ThenInclude(_ => _.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(_ => _.Id)
                         .Where(_ => _.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Aluno[] GetAlynosByDisciplinaId(int disciplinaId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Disciplina)
                             .ThenInclude(_ => _.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(_ => _.Id)
                         .Where(_ => _.AlunoDisciplinas.Any(_ => _.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        // Professor
        public Professor[] GetAllProfessores(bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (incluirAlunos)
            {
                query = query.Include(_ => _.Disciplinas)
                             .ThenInclude(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(_ => _.Id);

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (incluirAlunos)
            {
                query = query.Include(_ => _.Disciplinas)
                             .ThenInclude(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(_ => _.Id)
                         .Where(_ => _.Id == professorId);

            return query.FirstOrDefault();
        }

        public Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (incluirAlunos)
            {
                query = query.Include(_ => _.Disciplinas)
                             .ThenInclude(_ => _.AlunoDisciplinas)
                             .ThenInclude(_ => _.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(_ => _.Id)
                         .Where(_ => _.Disciplinas.Any(_ => _.Id == disciplinaId));

            return query.ToArray();
        }
    }
}