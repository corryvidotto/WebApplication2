using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Domain.Entities

{
    public class ResourceBook
    {
        private decimal _totPages;
        private readonly decimal _readPages;

        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
        [MaxLength(50)]
        public string? Author { get; set; }
        public int? Pages { get; set; }
        public double? Cost { get; set; }

        public DateOnly? PublishDate { get; set; }
        /// <summary>
        /// Default Constructor is necessary to create Initial Migration
        /// </summary>
        public ResourceBook()
        {

        }

        public ResourceBook(int TotalPages, int ReadPages)//Constructor 1: integer parameters
        {
            _totPages = TotalPages;
            _readPages = ReadPages;
            CalcRemainingPages(TotalPages, ReadPages);
        }

        public ResourceBook(decimal totPages, decimal readPages)//Constructor 2: decimal parameters
        {
            _totPages = totPages;
            _readPages = readPages;
            CalcPercentageRead(_totPages, readPages);
        }

        public int CalcRemainingPages(int _totPages, int _readPages)
        {
            int _remainingPages = _totPages - _readPages;
            return _remainingPages;
            throw new NotImplementedException();
        }

        public decimal CalcPercentageRead(decimal theTotalPages, decimal theReadPages)
        {
            decimal _pRead = (theReadPages / theTotalPages) * 100;
            return _pRead;
            throw new NotImplementedException();
        }
    }
}
