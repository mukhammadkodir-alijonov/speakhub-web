namespace SpeakHub.Service.ViewModels.TweetViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public string TweetText { get; set; } = string.Empty;
        public string EditTweetText { get; set; } = string.Empty;
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        /*public static implicit operator TweetViewModel(Tweet model)
        {
            return new TweetViewModel
            {
                Id = model.Id,
                TweetText = model.TweetText,
                EditTweetText = model.EditTweetText
            };
        }*/
    }
}
