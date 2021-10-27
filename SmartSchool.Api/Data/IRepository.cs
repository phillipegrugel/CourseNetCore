using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();
         Aluno[] GetAllAlunos(bool incluirProfessor = false);
        Aluno GetAlynoById(int alunoId, bool incluirProfessor = false);
        Aluno[] GetAlynosByDisciplinaId(int disciplinaId, bool incluirProfessor = false);
        Professor[] GetAllProfessores(bool incluirAlunos = false);
        Professor GetProfessorById(int professorId, bool incluirAlunos = false);
        Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool incluirAlunos = false);
    }
}