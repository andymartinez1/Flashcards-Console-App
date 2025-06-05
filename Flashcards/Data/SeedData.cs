using Flashcards.Models;

namespace Flashcards.Data;

public class SeedData
{
    internal static void SeedFlashcards()
    {
        List<Category> categories = new()
        {
            new Category { Name = "Math" },
            new Category { Name = "Science" },
            new Category { Name = "History" },
        };

        List<Flashcard> flashcards = new()
        {
            new Flashcard { CategoryId = 1, Question = "Question 1 - 1 ", Answer = "Answer 1" },
            new Flashcard { CategoryId = 1, Question = "Question 2 - 1", Answer = "Answer 2" },
            new Flashcard { CategoryId = 1, Question = "Question 3 - 1", Answer = "Answer 3" },
            new Flashcard { CategoryId = 2, Question = "Question 1 - 2", Answer = "Answer 1" },
            new Flashcard { CategoryId = 2, Question = "Question 2 - 2", Answer = "Answer 2" },
            new Flashcard { CategoryId = 2, Question = "Question 3 - 2", Answer = "Answer 3" },
            new Flashcard { CategoryId = 3, Question = "Question 1 - 3", Answer = "Answer 1" },
            new Flashcard { CategoryId = 3, Question = "Question 2 - 3", Answer = "Answer 2" },
            new Flashcard { CategoryId = 3, Question = "Question 3 - 3", Answer = "Answer 3" },
        };

        DataConnection dataConnection = new DataConnection();
        dataConnection.DeleteTables();
        dataConnection.CreateDatabase();
        dataConnection.InsertSeedSessions(categories, flashcards);
    }
}