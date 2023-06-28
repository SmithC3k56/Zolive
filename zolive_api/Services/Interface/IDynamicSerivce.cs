using zolive_api.Models.Dynamic;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
  public interface IDynamicSerivce
  {
        
    Task<int> report(CmfDynamicReport data);
    Task<IList<CmfDynamicReportClassify>> getReportlist();
    Task<int> isCommentlike(ulong uid, ulong commentid);
    Task<int> reduceCommentLike(ulong uid, ulong commentid);
    Task<int> addtoCommentLike(ulong uid, ulong commentid, ulong touid, ulong dynamicid);
    Task<LikeModel?> addCommentLike(string lan, ulong uid, ulong commentid);
    Task<LikeModel?> addLike(string lan, ulong uid, ulong dynamicid);
    Task<int> addtoLike(ulong uid, ulong dynamicid);
    Task<int> reduceLike(ulong uid, ulong dynamicid);
    Task<GetCommentModel> getComments(string lan, ulong uid, ulong dynamicid, int p);
    Task<sbyte> ifCommentLike(ulong uid, ulong commentid);
    Task<IList<DynamicModel>> getHomeDynamic(string lan, ulong uid, ulong touid, int p);
    Task<IList<DynamicModel>> getNewDynamic(string lan, ulong uid, int p);
    Task<IList<DynamicModel>> getAttentionDynamic(string lan, ulong uid, int p);
    Task<IList<DynamicModel>> getRecommendDynamics(string lan, ulong uid, int p);
    Task<DynamicModel> handleDynamic(string lan, DynamicModel v, ulong uid);
    Task<int> isdynamiclike(ulong uid, ulong dynamicid);
    Task<int> setDynamic(CmfDynamic data);
    Task<SetCommentModel> setComment(CmfDynamicComment data);
  }
}
