namespace BTL_LWNC_WebAmNhac.Models.ViewModels
{
    public class SongListViewModel
    {
        public IEnumerable<Song> Songs { get; set;}=Enumerable.Empty<Song>();

        public PagingInfo PagingInfo { get; set;} = new PagingInfo();
    }
}
