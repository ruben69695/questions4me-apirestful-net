using questions4me_apirestful_net.Models;

namespace questions4me_apirestful_net.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    { }

    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(Context context) : base(context)
        { }
    }
}