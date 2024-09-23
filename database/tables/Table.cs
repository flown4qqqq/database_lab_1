using Atk;

namespace dblaba.Database.Tables {
    abstract public class Table {
        public abstract string tableName { get; }
        public abstract void Create(bool forced);

        public bool IsCreated() {
            return QueryBuilder.IsTableCreated(tableName);
        }

    }
}
