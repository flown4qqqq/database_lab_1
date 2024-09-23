using System.Diagnostics;
using Atk;

namespace dblaba.Database.Tables {
    abstract public class Table {
        public abstract string Name { get; }
        public abstract void Create(bool forced);

        private bool isCreated() {
            return QueryBuilder.IsTableCreated(Name);
        }

        public enum ProcessResult {
            Drop,
            Nothing,
            Break
        };

        public ProcessResult ProcessDrop(bool forced) {
            if (isCreated()) {
                if (forced) {
                    var query = string.Format(@"
                        DROP TABLE {0} CASCADE;
                    ", Name);

                    Client.ExecuteQuite(query);
                    return ProcessResult.Drop;
                } else {
                    System.Console.WriteLine(string.Format("Table '{0}' already exist, so it was not created", Name));
                    return ProcessResult.Break;
                }
            }

            return ProcessResult.Nothing;
        }
    }
}
