using System.Linq;
using Microsoft.EntityFrameworkCore;
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