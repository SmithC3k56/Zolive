using zolive_api.Models.Dynamic;
using zolive_api.Models.Video;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface IVideoService
    {
        Task<int> setVideo(CmfVideo data, int music_id);
        Task<int> report(CmfVideoReport data);
        Task<IList<CmfVideoReportClassify>?> getReportContentlist();
        Task<IList<VideoModel>> getVideoList(string? lan, ulong uid, int p);
        Task<bool> addView(ulong videoid);
        Task<bool> setConversion(ulong videoid);
        Task<IList<VideoModel>> getClassVideo(string? lan, int videoclassid, ulong uid, int p);
        Task<VideoModel> handleVideo(string? lan, ulong uid, VideoModel v);
        Task<LikeModel?> addLike(string lan, ulong uid, ulong videoid);
        Task<ResultComment> getComments(string lan, ulong uid, ulong videoid, int p);
        Task<LikeModel?> addCommentLike(string lan, ulong uid, ulong commentid);
        Task<SetCommentModel> setComment(CmfVideoComment data);
    }
}
