using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteKeeper.Models;

namespace NoteKeeper.Services
{
    public class MockPluralsightDataStore : IPluralsightDataStore
    {
        private static readonly List<String> mockCourses;
        private static readonly List<Note> mockNotes;
        private static int nextNoteId;

        static MockPluralsightDataStore()
        {
            mockCourses = new List<string>
            {
                "Introduction to Xamarin.Forms",
                "Android Apps with Kotlin: First App",
                "Managing Android App Data with SQLite",
                "Bananas With Melons",
                "Smoothies just as you liked it",
                "Tester just to write that information in!",
                "7th test",
            };

            mockNotes = new List<Note>
            {
                new Note { Id="0", Heading="UI Code",
                    Text="Xamarin.Forms allows UI code to be shared", Course=mockCourses[0] },
                new Note { Id="1", Heading="Sharing Code",
                    Text="With Xamarin.Forms code can be shared across iOS, Android, and UWP", Course=mockCourses[4] },
                new Note { Id="2", Heading="Cross-platform Database",
                    Text="SQLite is a great storage solution for both Android and iOS", Course=mockCourses[2] },
                new Note { Id="3", Heading="Using Kotlin",
                    Text="For those prefering Java-like languages, Kotlin is a great choice for Android", Course=mockCourses[1] },
                new Note { Id="4", Heading="Data Binding",
                    Text="Data binding simplifies connecting app data to the UI", Course=mockCourses[3] },
                new Note { Id="5", Heading="Tester for Writing",
                    Text="Data Is Binding yep", Course=mockCourses[5] },
                new Note { Id="6", Heading="7th test for Writing",
                    Text="Data Is Binding yep 7th time", Course=mockCourses[6] },
            };

            nextNoteId = mockNotes.Count;

        }

        public async Task<String> AddNoteAsync(Note courseNote)
        {
            lock (this)
            {
                courseNote.Id = nextNoteId.ToString();
                mockNotes.Add(courseNote);
                nextNoteId++;
            }
            return await Task.FromResult(courseNote.Id);
        }

        public async Task<bool> UpdateNoteAsync(Note courseNote)
        {
            var noteIndex = mockNotes.FindIndex((Note arg) => arg.Id == courseNote.Id);
            var noteFound = noteIndex != -1;
            if (noteFound)
            {
                mockNotes[noteIndex].Heading = courseNote.Heading;
                mockNotes[noteIndex].Text = courseNote.Text;
                mockNotes[noteIndex].Course = courseNote.Course;
            }
            return await Task.FromResult(noteFound);
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            
            var note = mockNotes.FirstOrDefault(courseNote => courseNote.Id == id);

            // Make a copy of the note to simulate reading from an external datastore
            var returnNote = CopyNote(note);
            return await Task.FromResult(returnNote);
        }

        public async Task<IList<Note>> GetNotesAsync()
        {
            // Make a copy of the notes to simulate reading from an external datastore
            var returnNotes = new List<Note>();
            foreach (var note in mockNotes)
                returnNotes.Add(CopyNote(note));
            return await Task.FromResult(returnNotes);
        }

        public async Task<IList<String>> GetCoursesAsync()
        {
            return await Task.FromResult(mockCourses);
        }

        private static Note CopyNote(Note note)
        {
            return new Note { Id = note.Id, Heading = note.Heading, Text = note.Text, Course = note.Course };
        }
    }

}
