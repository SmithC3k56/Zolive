using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace zolive_db.Models
{
    public partial class newliveContext : DbContext
    {
        public newliveContext()
        {
        }

        public newliveContext(DbContextOptions<newliveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CmfAd> CmfAds { get; set; } = null!;
        public virtual DbSet<CmfAd1> CmfAds1 { get; set; } = null!;
        public virtual DbSet<CmfAdminLog> CmfAdminLogs { get; set; } = null!;
        public virtual DbSet<CmfAdminMenu> CmfAdminMenus { get; set; } = null!;
        public virtual DbSet<CmfAdsSort> CmfAdsSorts { get; set; } = null!;
        public virtual DbSet<CmfAgent> CmfAgents { get; set; } = null!;
        public virtual DbSet<CmfAgentCode> CmfAgentCodes { get; set; } = null!;
        public virtual DbSet<CmfAgentProfit> CmfAgentProfits { get; set; } = null!;
        public virtual DbSet<CmfAgentProfitRecode> CmfAgentProfitRecodes { get; set; } = null!;
        public virtual DbSet<CmfArtificial> CmfArtificials { get; set; } = null!;
        public virtual DbSet<CmfAsset> CmfAssets { get; set; } = null!;
        public virtual DbSet<CmfAuthAccess> CmfAuthAccesses { get; set; } = null!;
        public virtual DbSet<CmfAuthRule> CmfAuthRules { get; set; } = null!;
        public virtual DbSet<CmfBackpack> CmfBackpacks { get; set; } = null!;
        public virtual DbSet<CmfBalanceChargeAdmin> CmfBalanceChargeAdmins { get; set; } = null!;
        public virtual DbSet<CmfCar> CmfCars { get; set; } = null!;
        public virtual DbSet<CmfCarUser> CmfCarUsers { get; set; } = null!;
        public virtual DbSet<CmfCashAccount> CmfCashAccounts { get; set; } = null!;
        public virtual DbSet<CmfCashRecord> CmfCashRecords { get; set; } = null!;
        public virtual DbSet<CmfChargeAdmin> CmfChargeAdmins { get; set; } = null!;
        public virtual DbSet<CmfChargeRule> CmfChargeRules { get; set; } = null!;
        public virtual DbSet<CmfChargeUser> CmfChargeUsers { get; set; } = null!;
        public virtual DbSet<CmfCodepayPrivate> CmfCodepayPrivates { get; set; } = null!;
        public virtual DbSet<CmfComment> CmfComments { get; set; } = null!;
        public virtual DbSet<CmfComment1> CmfComments1 { get; set; } = null!;
        public virtual DbSet<CmfCommonActionLog> CmfCommonActionLogs { get; set; } = null!;
        public virtual DbSet<CmfConfig> CmfConfigs { get; set; } = null!;
        public virtual DbSet<CmfConfigPrivate> CmfConfigPrivates { get; set; } = null!;
        public virtual DbSet<CmfDefaultAvatar> CmfDefaultAvatars { get; set; } = null!;
        public virtual DbSet<CmfDynamic> CmfDynamics { get; set; } = null!;
        public virtual DbSet<CmfDynamicComment> CmfDynamicComments { get; set; } = null!;
        public virtual DbSet<CmfDynamicCommentsLike> CmfDynamicCommentsLikes { get; set; } = null!;
        public virtual DbSet<CmfDynamicLike> CmfDynamicLikes { get; set; } = null!;
        public virtual DbSet<CmfDynamicReport> CmfDynamicReports { get; set; } = null!;
        public virtual DbSet<CmfDynamicReportClassify> CmfDynamicReportClassifies { get; set; } = null!;
        public virtual DbSet<CmfExperlevel> CmfExperlevels { get; set; } = null!;
        public virtual DbSet<CmfExperlevelAnchor> CmfExperlevelAnchors { get; set; } = null!;
        public virtual DbSet<CmfFamily> CmfFamilies { get; set; } = null!;
        public virtual DbSet<CmfFamilyProfit> CmfFamilyProfits { get; set; } = null!;
        public virtual DbSet<CmfFamilyUser> CmfFamilyUsers { get; set; } = null!;
        public virtual DbSet<CmfFamilyUserDivideApply> CmfFamilyUserDivideApplies { get; set; } = null!;
        public virtual DbSet<CmfFeedback> CmfFeedbacks { get; set; } = null!;
        public virtual DbSet<CmfGame> CmfGames { get; set; } = null!;
        public virtual DbSet<CmfGamerecord> CmfGamerecords { get; set; } = null!;
        public virtual DbSet<CmfGetcodeLimitIp> CmfGetcodeLimitIps { get; set; } = null!;
        public virtual DbSet<CmfGift> CmfGifts { get; set; } = null!;
        public virtual DbSet<CmfGiftLuckRate> CmfGiftLuckRates { get; set; } = null!;
        public virtual DbSet<CmfGiftSort> CmfGiftSorts { get; set; } = null!;
        public virtual DbSet<CmfGuard> CmfGuards { get; set; } = null!;
        public virtual DbSet<CmfGuardUser> CmfGuardUsers { get; set; } = null!;
        public virtual DbSet<CmfGuardUser1> CmfGuardUsers1 { get; set; } = null!;
        public virtual DbSet<CmfGuide> CmfGuides { get; set; } = null!;
        public virtual DbSet<CmfHook> CmfHooks { get; set; } = null!;
        public virtual DbSet<CmfHookPlugin> CmfHookPlugins { get; set; } = null!;
        public virtual DbSet<CmfImpressionLabel> CmfImpressionLabels { get; set; } = null!;
        public virtual DbSet<CmfInstruction> CmfInstructions { get; set; } = null!;
        public virtual DbSet<CmfJackpot> CmfJackpots { get; set; } = null!;
        public virtual DbSet<CmfJackpotLevel> CmfJackpotLevels { get; set; } = null!;
        public virtual DbSet<CmfJackpotRate> CmfJackpotRates { get; set; } = null!;
        public virtual DbSet<CmfLabel> CmfLabels { get; set; } = null!;
        public virtual DbSet<CmfLabelUser> CmfLabelUsers { get; set; } = null!;
        public virtual DbSet<CmfLevel> CmfLevels { get; set; } = null!;
        public virtual DbSet<CmfLevelAnchor> CmfLevelAnchors { get; set; } = null!;
        public virtual DbSet<CmfLiang> CmfLiangs { get; set; } = null!;
        public virtual DbSet<CmfLink> CmfLinks { get; set; } = null!;
        public virtual DbSet<CmfLink1> CmfLinks1 { get; set; } = null!;
        public virtual DbSet<CmfLive> CmfLives { get; set; } = null!;
        public virtual DbSet<CmfLiveBan> CmfLiveBans { get; set; } = null!;
        public virtual DbSet<CmfLiveClass> CmfLiveClasses { get; set; } = null!;
        public virtual DbSet<CmfLiveKick> CmfLiveKicks { get; set; } = null!;
        public virtual DbSet<CmfLiveManager> CmfLiveManagers { get; set; } = null!;
        public virtual DbSet<CmfLiveRecord> CmfLiveRecords { get; set; } = null!;
        public virtual DbSet<CmfLiveShut> CmfLiveShuts { get; set; } = null!;
        public virtual DbSet<CmfLoginbonu> CmfLoginbonus { get; set; } = null!;
        public virtual DbSet<CmfLuckRate> CmfLuckRates { get; set; } = null!;
        public virtual DbSet<CmfMenu> CmfMenus { get; set; } = null!;
        public virtual DbSet<CmfMusic> CmfMusics { get; set; } = null!;
        public virtual DbSet<CmfMusicClassify> CmfMusicClassifies { get; set; } = null!;
        public virtual DbSet<CmfMusicCollection> CmfMusicCollections { get; set; } = null!;
        public virtual DbSet<CmfNav> CmfNavs { get; set; } = null!;
        public virtual DbSet<CmfNavCat> CmfNavCats { get; set; } = null!;
        public virtual DbSet<CmfNavMenu> CmfNavMenus { get; set; } = null!;
        public virtual DbSet<CmfOauthUser> CmfOauthUsers { get; set; } = null!;
        public virtual DbSet<CmfOption> CmfOptions { get; set; } = null!;
        public virtual DbSet<CmfOption1> CmfOptions1 { get; set; } = null!;
        public virtual DbSet<CmfPageSetting> CmfPageSettings { get; set; } = null!;
        public virtual DbSet<CmfPaidprogram> CmfPaidprograms { get; set; } = null!;
        public virtual DbSet<CmfPaidprogramApply> CmfPaidprogramApplies { get; set; } = null!;
        public virtual DbSet<CmfPaidprogramClass> CmfPaidprogramClasses { get; set; } = null!;
        public virtual DbSet<CmfPaidprogramComment> CmfPaidprogramComments { get; set; } = null!;
        public virtual DbSet<CmfPaidprogramOrder> CmfPaidprogramOrders { get; set; } = null!;
        public virtual DbSet<CmfPayMethod> CmfPayMethods { get; set; } = null!;
        public virtual DbSet<CmfPhonePrefix> CmfPhonePrefixes { get; set; } = null!;
        public virtual DbSet<CmfPlugin> CmfPlugins { get; set; } = null!;
        public virtual DbSet<CmfPlugin1> CmfPlugins1 { get; set; } = null!;
        public virtual DbSet<CmfPortalCategory> CmfPortalCategories { get; set; } = null!;
        public virtual DbSet<CmfPortalCategoryPost> CmfPortalCategoryPosts { get; set; } = null!;
        public virtual DbSet<CmfPortalPost> CmfPortalPosts { get; set; } = null!;
        public virtual DbSet<CmfPortalTag> CmfPortalTags { get; set; } = null!;
        public virtual DbSet<CmfPortalTagPost> CmfPortalTagPosts { get; set; } = null!;
        public virtual DbSet<CmfPost> CmfPosts { get; set; } = null!;
        public virtual DbSet<CmfPushrecord> CmfPushrecords { get; set; } = null!;
        public virtual DbSet<CmfReceive> CmfReceives { get; set; } = null!;
        public virtual DbSet<CmfRecord> CmfRecords { get; set; } = null!;
        public virtual DbSet<CmfRecycleBin> CmfRecycleBins { get; set; } = null!;
        public virtual DbSet<CmfRed> CmfReds { get; set; } = null!;
        public virtual DbSet<CmfRedRecord> CmfRedRecords { get; set; } = null!;
        public virtual DbSet<CmfReport> CmfReports { get; set; } = null!;
        public virtual DbSet<CmfReportClassify> CmfReportClassifies { get; set; } = null!;
        public virtual DbSet<CmfRole> CmfRoles { get; set; } = null!;
        public virtual DbSet<CmfRoleUser> CmfRoleUsers { get; set; } = null!;
        public virtual DbSet<CmfRoute> CmfRoutes { get; set; } = null!;
        public virtual DbSet<CmfSellerGoodsClass> CmfSellerGoodsClasses { get; set; } = null!;
        public virtual DbSet<CmfSendcode> CmfSendcodes { get; set; } = null!;
        public virtual DbSet<CmfSettlementCharge> CmfSettlementCharges { get; set; } = null!;
        public virtual DbSet<CmfSettlementChargeRecord> CmfSettlementChargeRecords { get; set; } = null!;
        public virtual DbSet<CmfSettlementVote> CmfSettlementVotes { get; set; } = null!;
        public virtual DbSet<CmfSettlementVotesRecord> CmfSettlementVotesRecords { get; set; } = null!;
        public virtual DbSet<CmfShopAddress> CmfShopAddresses { get; set; } = null!;
        public virtual DbSet<CmfShopApply> CmfShopApplies { get; set; } = null!;
        public virtual DbSet<CmfShopBond> CmfShopBonds { get; set; } = null!;
        public virtual DbSet<CmfShopExpress> CmfShopExpresses { get; set; } = null!;
        public virtual DbSet<CmfShopGood> CmfShopGoods { get; set; } = null!;
        public virtual DbSet<CmfShopGoodsClass> CmfShopGoodsClasses { get; set; } = null!;
        public virtual DbSet<CmfShopOrder> CmfShopOrders { get; set; } = null!;
        public virtual DbSet<CmfShopOrderComment> CmfShopOrderComments { get; set; } = null!;
        public virtual DbSet<CmfShopOrderMessage> CmfShopOrderMessages { get; set; } = null!;
        public virtual DbSet<CmfShopOrderRefund> CmfShopOrderRefunds { get; set; } = null!;
        public virtual DbSet<CmfShopOrderRefundList> CmfShopOrderRefundLists { get; set; } = null!;
        public virtual DbSet<CmfShopPlatformReason> CmfShopPlatformReasons { get; set; } = null!;
        public virtual DbSet<CmfShopPoint> CmfShopPoints { get; set; } = null!;
        public virtual DbSet<CmfShopRefundReason> CmfShopRefundReasons { get; set; } = null!;
        public virtual DbSet<CmfShopRefuseReason> CmfShopRefuseReasons { get; set; } = null!;
        public virtual DbSet<CmfSlide> CmfSlides { get; set; } = null!;
        public virtual DbSet<CmfSlideCat> CmfSlideCats { get; set; } = null!;
        public virtual DbSet<CmfSlideItem> CmfSlideItems { get; set; } = null!;
        public virtual DbSet<CmfSomething> CmfSomethings { get; set; } = null!;
        public virtual DbSet<CmfTask> CmfTasks { get; set; } = null!;
        public virtual DbSet<CmfTerm> CmfTerms { get; set; } = null!;
        public virtual DbSet<CmfTermRelationship> CmfTermRelationships { get; set; } = null!;
        public virtual DbSet<CmfTheDetail> CmfTheDetails { get; set; } = null!;
        public virtual DbSet<CmfTheme> CmfThemes { get; set; } = null!;
        public virtual DbSet<CmfThemeFile> CmfThemeFiles { get; set; } = null!;
        public virtual DbSet<CmfThirdPartyUser> CmfThirdPartyUsers { get; set; } = null!;
        public virtual DbSet<CmfTurntable> CmfTurntables { get; set; } = null!;
        public virtual DbSet<CmfTurntableCon> CmfTurntableCons { get; set; } = null!;
        public virtual DbSet<CmfTurntableLog> CmfTurntableLogs { get; set; } = null!;
        public virtual DbSet<CmfTurntableWin> CmfTurntableWins { get; set; } = null!;
        public virtual DbSet<CmfUser> CmfUsers { get; set; } = null!;
        public virtual DbSet<CmfUser1> CmfUsers1 { get; set; } = null!;
        public virtual DbSet<CmfUserAction> CmfUserActions { get; set; } = null!;
        public virtual DbSet<CmfUserActionLog> CmfUserActionLogs { get; set; } = null!;
        public virtual DbSet<CmfUserAttention> CmfUserAttentions { get; set; } = null!;
        public virtual DbSet<CmfUserAuth> CmfUserAuths { get; set; } = null!;
        public virtual DbSet<CmfUserBalanceCashrecord> CmfUserBalanceCashrecords { get; set; } = null!;
        public virtual DbSet<CmfUserBalanceLog> CmfUserBalanceLogs { get; set; } = null!;
        public virtual DbSet<CmfUserBalanceRecord> CmfUserBalanceRecords { get; set; } = null!;
        public virtual DbSet<CmfUserBanrecord> CmfUserBanrecords { get; set; } = null!;
        public virtual DbSet<CmfUserBlack> CmfUserBlacks { get; set; } = null!;
        public virtual DbSet<CmfUserCoinrecord> CmfUserCoinrecords { get; set; } = null!;
        public virtual DbSet<CmfUserFavorite> CmfUserFavorites { get; set; } = null!;
        public virtual DbSet<CmfUserGoodsVisit> CmfUserGoodsVisits { get; set; } = null!;
        public virtual DbSet<CmfUserLike> CmfUserLikes { get; set; } = null!;
        public virtual DbSet<CmfUserLoginAttempt> CmfUserLoginAttempts { get; set; } = null!;
        public virtual DbSet<CmfUserPushid> CmfUserPushids { get; set; } = null!;
        public virtual DbSet<CmfUserScoreLog> CmfUserScoreLogs { get; set; } = null!;
        public virtual DbSet<CmfUserScorerecord> CmfUserScorerecords { get; set; } = null!;
        public virtual DbSet<CmfUserSign> CmfUserSigns { get; set; } = null!;
        public virtual DbSet<CmfUserSuper> CmfUserSupers { get; set; } = null!;
        public virtual DbSet<CmfUserToken> CmfUserTokens { get; set; } = null!;
        public virtual DbSet<CmfUserVoterecord> CmfUserVoterecords { get; set; } = null!;
        public virtual DbSet<CmfUserZombie> CmfUserZombies { get; set; } = null!;
        public virtual DbSet<CmfUsersAgent> CmfUsersAgents { get; set; } = null!;
        public virtual DbSet<CmfUsersAgentCode> CmfUsersAgentCodes { get; set; } = null!;
        public virtual DbSet<CmfUsersAgentProfit> CmfUsersAgentProfits { get; set; } = null!;
        public virtual DbSet<CmfUsersAgentProfitRecode> CmfUsersAgentProfitRecodes { get; set; } = null!;
        public virtual DbSet<CmfUsersAttention> CmfUsersAttentions { get; set; } = null!;
        public virtual DbSet<CmfUsersAuth> CmfUsersAuths { get; set; } = null!;
        public virtual DbSet<CmfUsersBlack> CmfUsersBlacks { get; set; } = null!;
        public virtual DbSet<CmfUsersCar> CmfUsersCars { get; set; } = null!;
        public virtual DbSet<CmfUsersCashAccount> CmfUsersCashAccounts { get; set; } = null!;
        public virtual DbSet<CmfUsersCashrecord> CmfUsersCashrecords { get; set; } = null!;
        public virtual DbSet<CmfUsersCharge> CmfUsersCharges { get; set; } = null!;
        public virtual DbSet<CmfUsersChargeAdmin> CmfUsersChargeAdmins { get; set; } = null!;
        public virtual DbSet<CmfUsersCoinrecord> CmfUsersCoinrecords { get; set; } = null!;
        public virtual DbSet<CmfUsersFamily> CmfUsersFamilies { get; set; } = null!;
        public virtual DbSet<CmfUsersGamerecord> CmfUsersGamerecords { get; set; } = null!;
        public virtual DbSet<CmfUsersLabel> CmfUsersLabels { get; set; } = null!;
        public virtual DbSet<CmfUsersLaravelPayLog> CmfUsersLaravelPayLogs { get; set; } = null!;
        public virtual DbSet<CmfUsersLive> CmfUsersLives { get; set; } = null!;
        public virtual DbSet<CmfUsersLivemanager> CmfUsersLivemanagers { get; set; } = null!;
        public virtual DbSet<CmfUsersLiverecord> CmfUsersLiverecords { get; set; } = null!;
        public virtual DbSet<CmfUsersMusic> CmfUsersMusics { get; set; } = null!;
        public virtual DbSet<CmfUsersMusicClassify> CmfUsersMusicClassifies { get; set; } = null!;
        public virtual DbSet<CmfUsersMusicCollection> CmfUsersMusicCollections { get; set; } = null!;
        public virtual DbSet<CmfUsersProxy> CmfUsersProxies { get; set; } = null!;
        public virtual DbSet<CmfUsersPushid> CmfUsersPushids { get; set; } = null!;
        public virtual DbSet<CmfUsersReport> CmfUsersReports { get; set; } = null!;
        public virtual DbSet<CmfUsersReportClassify> CmfUsersReportClassifies { get; set; } = null!;
        public virtual DbSet<CmfUsersSign> CmfUsersSigns { get; set; } = null!;
        public virtual DbSet<CmfUsersSuper> CmfUsersSupers { get; set; } = null!;
        public virtual DbSet<CmfUsersVideo> CmfUsersVideos { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoBlack> CmfUsersVideoBlacks { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoComment> CmfUsersVideoComments { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoCommentsLike> CmfUsersVideoCommentsLikes { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoLike> CmfUsersVideoLikes { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoReport> CmfUsersVideoReports { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoReportClassify> CmfUsersVideoReportClassifies { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoStep> CmfUsersVideoSteps { get; set; } = null!;
        public virtual DbSet<CmfUsersVideoView> CmfUsersVideoViews { get; set; } = null!;
        public virtual DbSet<CmfUsersVip> CmfUsersVips { get; set; } = null!;
        public virtual DbSet<CmfUsersVoterecord> CmfUsersVoterecords { get; set; } = null!;
        public virtual DbSet<CmfUsersZombie> CmfUsersZombies { get; set; } = null!;
        public virtual DbSet<CmfVerificationCode> CmfVerificationCodes { get; set; } = null!;
        public virtual DbSet<CmfVideo> CmfVideos { get; set; } = null!;
        public virtual DbSet<CmfVideoBlack> CmfVideoBlacks { get; set; } = null!;
        public virtual DbSet<CmfVideoClass> CmfVideoClasses { get; set; } = null!;
        public virtual DbSet<CmfVideoComment> CmfVideoComments { get; set; } = null!;
        public virtual DbSet<CmfVideoCommentsLike> CmfVideoCommentsLikes { get; set; } = null!;
        public virtual DbSet<CmfVideoLike> CmfVideoLikes { get; set; } = null!;
        public virtual DbSet<CmfVideoReport> CmfVideoReports { get; set; } = null!;
        public virtual DbSet<CmfVideoReportClassify> CmfVideoReportClassifies { get; set; } = null!;
        public virtual DbSet<CmfVideoStep> CmfVideoSteps { get; set; } = null!;
        public virtual DbSet<CmfVideoView> CmfVideoViews { get; set; } = null!;
        public virtual DbSet<CmfVip> CmfVips { get; set; } = null!;
        public virtual DbSet<CmfVipUser> CmfVipUsers { get; set; } = null!;
        public virtual DbSet<CodepayOrder> CodepayOrders { get; set; } = null!;
        public virtual DbSet<Foo> Foos { get; set; } = null!;
        public virtual DbSet<V1JiguangUserDatum> V1JiguangUserData { get; set; } = null!;
        public virtual DbSet<V1MessageTask> V1MessageTasks { get; set; } = null!;
        public virtual DbSet<V1PushMessageHistory> V1PushMessageHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=172.18.19.91;uid=root;pwd=new_password;database=newlive", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<CmfAd>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_ad");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.AdName, "ad_name")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 191 });

                entity.Property(e => e.AdId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ad_id")
                    .HasComment("广告id");

                entity.Property(e => e.AdContent)
                    .HasColumnType("text")
                    .HasColumnName("ad_content")
                    .HasComment("广告内容");

                entity.Property(e => e.AdName)
                    .HasColumnName("ad_name")
                    .HasComment("广告名称");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1显示，0不显示");
            });

            modelBuilder.Entity<CmfAd1>(entity =>
            {
                entity.ToTable("cmf_ads");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Des)
                    .HasMaxLength(255)
                    .HasColumnName("des")
                    .HasDefaultValueSql("'0'")
                    .HasComment("描述");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("广告名称");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(3)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("序号");

                entity.Property(e => e.Sid)
                    .HasColumnType("int(12)")
                    .HasColumnName("sid")
                    .HasComment("分类ID");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasComment("图片链接");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasComment("链接");
            });

            modelBuilder.Entity<CmfAdminLog>(entity =>
            {
                entity.ToTable("cmf_admin_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnType("text")
                    .HasColumnName("action")
                    .HasComment("操作内容");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasComment("管理员");

                entity.Property(e => e.Adminid)
                    .HasColumnType("int(11)")
                    .HasColumnName("adminid")
                    .HasComment("管理员ID");

                entity.Property(e => e.Ip)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ip")
                    .HasComment("IP地址");
            });

            modelBuilder.Entity<CmfAdminMenu>(entity =>
            {
                entity.ToTable("cmf_admin_menu");

                entity.HasComment("后台菜单表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Controller, "controller");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => e.Status, "status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(30)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("操作名称")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.App)
                    .HasMaxLength(40)
                    .HasColumnName("app")
                    .HasDefaultValueSql("''")
                    .HasComment("应用名")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Controller)
                    .HasMaxLength(30)
                    .HasColumnName("controller")
                    .HasDefaultValueSql("''")
                    .HasComment("控制器名")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Icon)
                    .HasMaxLength(20)
                    .HasColumnName("icon")
                    .HasDefaultValueSql("''")
                    .HasComment("菜单图标")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("菜单名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Param)
                    .HasMaxLength(50)
                    .HasColumnName("param")
                    .HasDefaultValueSql("''")
                    .HasComment("额外参数")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("parent_id")
                    .HasComment("父菜单id");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("''")
                    .HasComment("备注")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasComment("状态;1:显示,0:不显示");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("菜单类型;1:有界面可访问菜单,2:无界面可访问菜单,0:只作为菜单");
            });

            modelBuilder.Entity<CmfAdsSort>(entity =>
            {
                entity.ToTable("cmf_ads_sort");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("时间");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(3)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("序号");

                entity.Property(e => e.Sortname)
                    .HasMaxLength(20)
                    .HasColumnName("sortname")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名");
            });

            modelBuilder.Entity<CmfAgent>(entity =>
            {
                entity.ToTable("cmf_agent");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.OneUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("one_uid")
                    .HasComment("上级用户id");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfAgentCode>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_agent_code");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code")
                    .HasDefaultValueSql("''")
                    .HasComment("邀请码");
            });

            modelBuilder.Entity<CmfAgentProfit>(entity =>
            {
                entity.ToTable("cmf_agent_profit");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.OneProfit)
                    .HasColumnName("one_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("一级收益");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfAgentProfitRecode>(entity =>
            {
                entity.ToTable("cmf_agent_profit_recode");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("时间");

                entity.Property(e => e.OneProfit)
                    .HasColumnName("one_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("一级收益");

                entity.Property(e => e.OneUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("one_uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("一级ID");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'")
                    .HasComment("消费总数");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfArtificial>(entity =>
            {
                entity.ToTable("cmf_artificial");

                entity.HasComment("人工充值")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Money)
                    .HasMaxLength(32)
                    .HasColumnName("money")
                    .HasComment("可用额度");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .HasColumnName("name")
                    .HasComment("名称");

                entity.Property(e => e.PayAli)
                    .HasMaxLength(32)
                    .HasColumnName("pay_ali")
                    .HasComment("支付宝");

                entity.Property(e => e.Qq)
                    .HasMaxLength(32)
                    .HasColumnName("qq")
                    .HasComment("QQ");

                entity.Property(e => e.TheText)
                    .HasColumnType("text")
                    .HasColumnName("the_text");

                entity.Property(e => e.Wechat)
                    .HasMaxLength(32)
                    .HasColumnName("wechat")
                    .HasComment("微信");
            });

            modelBuilder.Entity<CmfAsset>(entity =>
            {
                entity.ToTable("cmf_asset");

                entity.HasComment("资源表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("上传时间");

                entity.Property(e => e.DownloadTimes)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("download_times")
                    .HasComment("下载次数");

                entity.Property(e => e.FileKey)
                    .HasMaxLength(64)
                    .HasColumnName("file_key")
                    .HasDefaultValueSql("''")
                    .HasComment("文件惟一码")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FileMd5)
                    .HasMaxLength(32)
                    .HasColumnName("file_md5")
                    .HasDefaultValueSql("''")
                    .HasComment("文件md5值")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(100)
                    .HasColumnName("file_path")
                    .HasDefaultValueSql("''")
                    .HasComment("文件路径,相对于upload目录,可以为url")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FileSha1)
                    .HasMaxLength(40)
                    .HasColumnName("file_sha1")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FileSize)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("file_size")
                    .HasComment("文件大小,单位B");

                entity.Property(e => e.Filename)
                    .HasMaxLength(100)
                    .HasColumnName("filename")
                    .HasDefaultValueSql("''")
                    .HasComment("文件名")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("其它详细信息,JSON格式");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:可用,0:不可用");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(10)
                    .HasColumnName("suffix")
                    .HasDefaultValueSql("''")
                    .HasComment("文件后缀名,不包括点");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfAuthAccess>(entity =>
            {
                entity.ToTable("cmf_auth_access");

                entity.HasComment("权限授权表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.HasIndex(e => e.RuleName, "rule_name");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("role_id")
                    .HasComment("角色");

                entity.Property(e => e.RuleName)
                    .HasMaxLength(100)
                    .HasColumnName("rule_name")
                    .HasDefaultValueSql("''")
                    .HasComment("规则唯一英文标识,全小写");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasComment("权限规则分类,请加应用前缀,如admin_");
            });

            modelBuilder.Entity<CmfAuthRule>(entity =>
            {
                entity.ToTable("cmf_auth_rule");

                entity.HasComment("权限规则表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.App, e.Status, e.Type }, "module");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id")
                    .HasComment("规则id,自增主键");

                entity.Property(e => e.App)
                    .HasMaxLength(40)
                    .HasColumnName("app")
                    .HasDefaultValueSql("''")
                    .HasComment("规则所属app");

                entity.Property(e => e.Condition)
                    .HasMaxLength(200)
                    .HasColumnName("condition")
                    .HasDefaultValueSql("''")
                    .HasComment("规则附加条件");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("规则唯一英文标识,全小写");

                entity.Property(e => e.Param)
                    .HasMaxLength(100)
                    .HasColumnName("param")
                    .HasDefaultValueSql("''")
                    .HasComment("额外url参数");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否有效(0:无效,1:有效)");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("规则描述")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasComment("权限规则分类，请加应用前缀,如admin_");
            });

            modelBuilder.Entity<CmfBackpack>(entity =>
            {
                entity.ToTable("cmf_backpack");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(11)")
                    .HasColumnName("giftid")
                    .HasComment("礼物ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfBalanceChargeAdmin>(entity =>
            {
                entity.ToTable("cmf_balance_charge_admin");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("''")
                    .HasComment("管理员");

                entity.Property(e => e.Balance)
                    .HasColumnType("int(20)")
                    .HasColumnName("balance")
                    .HasComment("金额");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''")
                    .HasComment("IP");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("充值对象ID");
            });

            modelBuilder.Entity<CmfCar>(entity =>
            {
                entity.ToTable("cmf_car");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(10)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam");

                entity.Property(e => e.Needcoin)
                    .HasColumnType("int(20)")
                    .HasColumnName("needcoin")
                    .HasComment("价格");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("积分价格");

                entity.Property(e => e.Swf)
                    .HasMaxLength(255)
                    .HasColumnName("swf")
                    .HasDefaultValueSql("''")
                    .HasComment("动画链接");

                entity.Property(e => e.Swftime)
                    .HasPrecision(10, 2)
                    .HasColumnName("swftime")
                    .HasComment("动画时长");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图片链接");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Words)
                    .HasMaxLength(255)
                    .HasColumnName("words")
                    .HasDefaultValueSql("''")
                    .HasComment("进场话术");

                entity.Property(e => e.WordsEn)
                    .HasMaxLength(255)
                    .HasColumnName("words_en")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.WordsNam)
                    .HasMaxLength(255)
                    .HasColumnName("words_nam")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CmfCarUser>(entity =>
            {
                entity.ToTable("cmf_car_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Carid)
                    .HasColumnType("int(11)")
                    .HasColumnName("carid")
                    .HasComment("坐骑ID");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("是否启用");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfCashAccount>(entity =>
            {
                entity.ToTable("cmf_cash_account");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Id, e.Uid }, "id_uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("账号");

                entity.Property(e => e.AccountBank)
                    .HasMaxLength(255)
                    .HasColumnName("account_bank")
                    .HasDefaultValueSql("''")
                    .HasComment("银行名称");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型，1表示支付宝，2表示微信，3表示银行卡");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfCashRecord>(entity =>
            {
                entity.ToTable("cmf_cash_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("帐号");

                entity.Property(e => e.AccountBank)
                    .HasMaxLength(255)
                    .HasColumnName("account_bank")
                    .HasDefaultValueSql("''")
                    .HasComment("银行名称");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.Money)
                    .HasColumnType("int(20)")
                    .HasColumnName("money")
                    .HasComment("提现金额");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(50)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("订单号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0审核中，1审核通过，2审核拒绝");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(100)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方订单号");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("账号类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Votes)
                    .HasColumnType("int(20)")
                    .HasColumnName("votes")
                    .HasComment("提现映票数");
            });

            modelBuilder.Entity<CmfChargeAdmin>(entity =>
            {
                entity.ToTable("cmf_charge_admin");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("''")
                    .HasComment("管理员");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(20)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''")
                    .HasComment("IP");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("充值对象ID");
            });

            modelBuilder.Entity<CmfChargeRule>(entity =>
            {
                entity.ToTable("cmf_charge_rules");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.CoinIos)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_ios")
                    .HasComment("苹果钻石数");

                entity.Property(e => e.Give)
                    .HasColumnType("int(11)")
                    .HasColumnName("give")
                    .HasComment("赠送钻石数");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Money)
                    .HasPrecision(11, 2)
                    .HasColumnName("money")
                    .HasComment("安卓金额");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasDefaultValueSql("''")
                    .HasComment("苹果项目ID");
            });

            modelBuilder.Entity<CmfChargeUser>(entity =>
            {
                entity.ToTable("cmf_charge_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Ambient)
                    .HasColumnName("ambient")
                    .HasComment("支付环境");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.CoinGive)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_give")
                    .HasComment("赠送钻石数");

                entity.Property(e => e.Je)
                    .HasPrecision(22, 2)
                    .HasColumnName("je")
                    .HasComment("额度");

                entity.Property(e => e.Money)
                    .HasPrecision(11, 2)
                    .HasColumnName("money")
                    .HasComment("金额");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(50)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("商家订单号");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否结算");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("充值对象ID");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(100)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方平台订单号");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("支付类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfCodepayPrivate>(entity =>
            {
                entity.ToTable("cmf_codepay_private");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(13)")
                    .HasColumnName("id");

                entity.Property(e => e.CodepayId)
                    .HasColumnType("int(255)")
                    .HasColumnName("codepay_id")
                    .HasDefaultValueSql("'1'")
                    .HasComment("码支付ID");

                entity.Property(e => e.CodepayKey)
                    .HasMaxLength(255)
                    .HasColumnName("codepay_key")
                    .HasDefaultValueSql("'60'")
                    .HasComment("码支付Key");

                entity.Property(e => e.CodepayMultiple)
                    .HasColumnType("int(255)")
                    .HasColumnName("codepay_multiple")
                    .HasComment("码支付倍数");
            });

            modelBuilder.Entity<CmfComment>(entity =>
            {
                entity.ToTable("cmf_comment");

                entity.HasComment("评论表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CreateTime, "create_time");

                entity.HasIndex(e => e.ObjectId, "object_id");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => e.Status, "status");

                entity.HasIndex(e => new { e.TableName, e.ObjectId, e.Status }, "table_id_status");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("评论内容")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("评论时间");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("delete_time")
                    .HasComment("删除时间");

                entity.Property(e => e.DislikeCount)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("dislike_count")
                    .HasComment("不喜欢数");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''")
                    .HasComment("评论者邮箱");

                entity.Property(e => e.Floor)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("floor")
                    .HasComment("楼层数");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("full_name")
                    .HasDefaultValueSql("''")
                    .HasComment("评论者昵称");

                entity.Property(e => e.LikeCount)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("like_count")
                    .HasComment("点赞数");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展属性")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("object_id")
                    .HasComment("评论内容 id");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id")
                    .HasComment("被回复的评论id");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''")
                    .HasComment("层级关系");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:已审核,0:未审核");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''")
                    .HasComment("评论内容所在表，不带表前缀");

                entity.Property(e => e.ToUserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("to_user_id")
                    .HasComment("被评论的用户id");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("评论类型；1实名评论");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url")
                    .HasComment("原文地址");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("发表评论的用户id");
            });

            modelBuilder.Entity<CmfComment1>(entity =>
            {
                entity.ToTable("cmf_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Status, "comment_approved_date_gmt");

                entity.HasIndex(e => e.Parentid, "comment_parent");

                entity.HasIndex(e => e.PostId, "comment_post_ID");

                entity.HasIndex(e => e.Createtime, "createtime");

                entity.HasIndex(e => new { e.PostTable, e.PostId, e.Status }, "table_id_status");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("评论内容");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasDefaultValueSql("'2000-01-01 00:00:00'")
                    .HasComment("评论时间");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasComment("评论者邮箱");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("full_name")
                    .HasComment("评论者昵称");

                entity.Property(e => e.Parentid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parentid")
                    .HasComment("被回复的评论id");

                entity.Property(e => e.Path)
                    .HasMaxLength(500)
                    .HasColumnName("path");

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("post_id")
                    .HasComment("评论内容 id");

                entity.Property(e => e.PostTable)
                    .HasMaxLength(100)
                    .HasColumnName("post_table")
                    .HasComment("评论内容所在表，不带表前缀");

                entity.Property(e => e.Status)
                    .HasColumnType("smallint(1)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1已审核，0未审核");

                entity.Property(e => e.ToUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("to_uid")
                    .HasComment("被评论的用户id");

                entity.Property(e => e.Type)
                    .HasColumnType("smallint(1)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("评论类型；1实名评论");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("发表评论的用户id");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasComment("原文地址");
            });

            modelBuilder.Entity<CmfCommonActionLog>(entity =>
            {
                entity.ToTable("cmf_common_action_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.User, e.Object, e.Action }, "user_object_action");

                entity.HasIndex(e => new { e.User, e.Object, e.Action, e.Ip }, "user_object_action_ip");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasComment("操作名称；格式规定为：应用名+控制器+操作名；也可自己定义格式只要不发生冲突且惟一；");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("访问次数");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasComment("访问者最后访问ip");

                entity.Property(e => e.LastTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("last_time")
                    .HasDefaultValueSql("'0'")
                    .HasComment("最后访问的时间戳");

                entity.Property(e => e.Object)
                    .HasMaxLength(100)
                    .HasColumnName("object")
                    .HasComment("访问对象的id,格式：不带前缀的表名+id;如posts1表示xx_posts表里id为1的记录");

                entity.Property(e => e.User)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfConfig>(entity =>
            {
                entity.ToTable("cmf_config");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(13)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''")
                    .HasComment("地址");

                entity.Property(e => e.ApkDes)
                    .HasMaxLength(255)
                    .HasColumnName("apk_des")
                    .HasDefaultValueSql("''")
                    .HasComment("APK版本更新说明");

                entity.Property(e => e.ApkEwm)
                    .HasMaxLength(255)
                    .HasColumnName("apk_ewm")
                    .HasDefaultValueSql("''")
                    .HasComment("android下载二维码");

                entity.Property(e => e.ApkUrl)
                    .HasMaxLength(255)
                    .HasColumnName("apk_url")
                    .HasComment("APK下载链接");

                entity.Property(e => e.ApkVer)
                    .HasMaxLength(255)
                    .HasColumnName("apk_ver")
                    .HasComment("APK版本号");

                entity.Property(e => e.AppAndroid)
                    .HasMaxLength(255)
                    .HasColumnName("app_android")
                    .HasComment("AndroidAPP下载链接");

                entity.Property(e => e.AppIos)
                    .HasMaxLength(255)
                    .HasColumnName("app_ios")
                    .HasComment("IOSAPP下载链接");

                entity.Property(e => e.Copyright)
                    .HasMaxLength(255)
                    .HasColumnName("copyright")
                    .HasDefaultValueSql("''")
                    .HasComment("版权信息");

                entity.Property(e => e.EnterTipLevel)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("enter_tip_level")
                    .HasDefaultValueSql("'1'")
                    .HasComment("金光一闪提示");

                entity.Property(e => e.ExRate)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ex_rate")
                    .HasDefaultValueSql("'9'")
                    .HasComment("映票兑换钻石比例");

                entity.Property(e => e.Fps)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("fps")
                    .HasComment("fps帧数");

                entity.Property(e => e.IosShelves)
                    .HasMaxLength(255)
                    .HasColumnName("ios_shelves")
                    .HasDefaultValueSql("''")
                    .HasComment("IOS上架版本号");

                entity.Property(e => e.IpaDes)
                    .HasMaxLength(255)
                    .HasColumnName("ipa_des")
                    .HasDefaultValueSql("''")
                    .HasComment("IPA版本更新说明");

                entity.Property(e => e.IpaEwm)
                    .HasMaxLength(255)
                    .HasColumnName("ipa_ewm")
                    .HasDefaultValueSql("''")
                    .HasComment("ios下载链接");

                entity.Property(e => e.IpaUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ipa_url")
                    .HasComment("IPA下载链接");

                entity.Property(e => e.IpaVer)
                    .HasMaxLength(255)
                    .HasColumnName("ipa_ver")
                    .HasComment("IPA版本号");

                entity.Property(e => e.Keyframe)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("keyframe")
                    .HasComment("关键帧");

                entity.Property(e => e.LiveHeight)
                    .HasMaxLength(255)
                    .HasColumnName("live_height")
                    .HasComment("推流分辨率高度");

                entity.Property(e => e.LiveTimeCoin)
                    .HasMaxLength(255)
                    .HasColumnName("live_time_coin")
                    .HasDefaultValueSql("''")
                    .HasComment("计时收费梯价");

                entity.Property(e => e.LiveType)
                    .HasMaxLength(255)
                    .HasColumnName("live_type")
                    .HasDefaultValueSql("''")
                    .HasComment("直播类型");

                entity.Property(e => e.LiveWidth)
                    .HasMaxLength(255)
                    .HasColumnName("live_width")
                    .HasComment("推流分辨率宽度");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(255)
                    .HasColumnName("login_type")
                    .HasDefaultValueSql("''")
                    .HasComment("登录方式");

                entity.Property(e => e.Lotterybase)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("lotterybase")
                    .HasDefaultValueSql("'1000000000'")
                    .HasComment("中奖基数");

                entity.Property(e => e.MaintainSwitch)
                    .HasColumnName("maintain_switch")
                    .HasComment("网站维护开关");

                entity.Property(e => e.MaintainTips)
                    .HasMaxLength(255)
                    .HasColumnName("maintain_tips")
                    .HasDefaultValueSql("''")
                    .HasComment("维护内容");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(255)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .HasComment("官网电话");

                entity.Property(e => e.NameCoin)
                    .HasMaxLength(255)
                    .HasColumnName("name_coin")
                    .HasComment("钻石名称");

                entity.Property(e => e.NameVotes)
                    .HasMaxLength(255)
                    .HasColumnName("name_votes")
                    .HasComment("映票名称");

                entity.Property(e => e.PubMsg)
                    .HasColumnType("text")
                    .HasColumnName("pub_msg")
                    .HasComment("公众号提示信息");

                entity.Property(e => e.QqDesc)
                    .HasMaxLength(255)
                    .HasColumnName("qq_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("qq描述");

                entity.Property(e => e.QqIcon)
                    .HasMaxLength(255)
                    .HasColumnName("qq_icon")
                    .HasDefaultValueSql("''")
                    .HasComment("qq图标");

                entity.Property(e => e.QqTitle)
                    .HasMaxLength(255)
                    .HasColumnName("qq_title")
                    .HasDefaultValueSql("''")
                    .HasComment("qq标题");

                entity.Property(e => e.QqUrl)
                    .HasMaxLength(255)
                    .HasColumnName("qq_url")
                    .HasDefaultValueSql("''")
                    .HasComment("qq链接");

                entity.Property(e => e.QrUrl)
                    .HasMaxLength(255)
                    .HasColumnName("qr_url")
                    .HasComment("二维码连接");

                entity.Property(e => e.Quality)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("quality")
                    .HasComment("品质");

                entity.Property(e => e.ShareDes)
                    .HasMaxLength(255)
                    .HasColumnName("share_des")
                    .HasComment("分享话术");

                entity.Property(e => e.ShareTitle)
                    .HasMaxLength(255)
                    .HasColumnName("share_title")
                    .HasComment("分享标题");

                entity.Property(e => e.ShareType)
                    .HasMaxLength(255)
                    .HasColumnName("share_type")
                    .HasDefaultValueSql("''")
                    .HasComment("分享类型");

                entity.Property(e => e.SinaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("sina_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("新浪描述");

                entity.Property(e => e.SinaIcon)
                    .HasMaxLength(255)
                    .HasColumnName("sina_icon")
                    .HasDefaultValueSql("''")
                    .HasComment("新浪图标");

                entity.Property(e => e.SinaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("sina_title")
                    .HasDefaultValueSql("''")
                    .HasComment("新浪标题");

                entity.Property(e => e.SinaUrl)
                    .HasMaxLength(255)
                    .HasColumnName("sina_url")
                    .HasDefaultValueSql("''")
                    .HasComment("新浪链接");

                entity.Property(e => e.Site)
                    .HasMaxLength(255)
                    .HasColumnName("site")
                    .HasComment("网站域名");

                entity.Property(e => e.Sitename)
                    .HasMaxLength(255)
                    .HasColumnName("sitename")
                    .HasComment("网站标题");

                entity.Property(e => e.SproutEye)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_eye")
                    .HasDefaultValueSql("'0'")
                    .HasComment("大眼默认值");

                entity.Property(e => e.SproutFace)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_face")
                    .HasDefaultValueSql("'0'")
                    .HasComment("瘦脸默认值");

                entity.Property(e => e.SproutKey)
                    .HasMaxLength(255)
                    .HasColumnName("sprout_key")
                    .HasDefaultValueSql("''")
                    .HasComment("萌颜授权码");

                entity.Property(e => e.SproutPink)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_pink")
                    .HasDefaultValueSql("'0'")
                    .HasComment("粉嫩默认值");

                entity.Property(e => e.SproutSaturated)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_saturated")
                    .HasDefaultValueSql("'0'")
                    .HasComment("饱和默认值");

                entity.Property(e => e.SproutSkin)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_skin")
                    .HasDefaultValueSql("'0'")
                    .HasComment("磨皮默认值");

                entity.Property(e => e.SproutWhite)
                    .HasColumnType("int(11)")
                    .HasColumnName("sprout_white")
                    .HasComment("美白默认值");

                entity.Property(e => e.VideoShareDes)
                    .HasMaxLength(255)
                    .HasColumnName("video_share_des")
                    .HasDefaultValueSql("''")
                    .HasComment("短视频分享话术");

                entity.Property(e => e.VideoShareTitle)
                    .HasMaxLength(255)
                    .HasColumnName("video_share_title")
                    .HasDefaultValueSql("''")
                    .HasComment("短视频分享标题");

                entity.Property(e => e.WechatEwm)
                    .HasMaxLength(255)
                    .HasColumnName("wechat_ewm")
                    .HasDefaultValueSql("''")
                    .HasComment("微信公众号");

                entity.Property(e => e.WxSiteurl)
                    .HasMaxLength(255)
                    .HasColumnName("wx_siteurl")
                    .HasComment("微信推广域名");
            });

            modelBuilder.Entity<CmfConfigPrivate>(entity =>
            {
                entity.ToTable("cmf_config_private");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(13)")
                    .HasColumnName("id");

                entity.Property(e => e.AdyApn)
                    .HasMaxLength(255)
                    .HasColumnName("ady_apn")
                    .HasDefaultValueSql("''")
                    .HasComment("奥点云AppName");

                entity.Property(e => e.AdyHlsPull)
                    .HasMaxLength(255)
                    .HasColumnName("ady_hls_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("奥点云HLS播流地址");

                entity.Property(e => e.AdyPull)
                    .HasMaxLength(255)
                    .HasColumnName("ady_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("奥点云播流地址");

                entity.Property(e => e.AdyPush)
                    .HasMaxLength(255)
                    .HasColumnName("ady_push")
                    .HasDefaultValueSql("''")
                    .HasComment("奥点云推流地址");

                entity.Property(e => e.AgentSwitch)
                    .HasColumnName("agent_switch")
                    .HasComment("分销开关");

                entity.Property(e => e.AliappCheck)
                    .HasMaxLength(255)
                    .HasColumnName("aliapp_check")
                    .HasComment("支付宝校验码");

                entity.Property(e => e.AliappKeyAndroid)
                    .HasColumnType("text")
                    .HasColumnName("aliapp_key_android")
                    .HasComment("支付宝安卓密钥");

                entity.Property(e => e.AliappKeyIos)
                    .HasColumnType("text")
                    .HasColumnName("aliapp_key_ios")
                    .HasComment("支付宝苹果密钥");

                entity.Property(e => e.AliappPartner)
                    .HasMaxLength(255)
                    .HasColumnName("aliapp_partner")
                    .HasComment("合作者身份ID");

                entity.Property(e => e.AliappPc)
                    .HasColumnType("int(10)")
                    .HasColumnName("aliapp_pc")
                    .HasComment("支付宝PC");

                entity.Property(e => e.AliappSellerId)
                    .HasMaxLength(255)
                    .HasColumnName("aliapp_seller_id")
                    .HasComment("支付宝帐号");

                entity.Property(e => e.AliappSwitch)
                    .HasColumnType("int(10)")
                    .HasColumnName("aliapp_switch")
                    .HasDefaultValueSql("'1'")
                    .HasComment("支付宝APP");

                entity.Property(e => e.AuctionSwitch)
                    .HasColumnName("auction_switch")
                    .HasComment("竞拍开关");

                entity.Property(e => e.AuthIslimit)
                    .HasColumnType("int(10)")
                    .HasColumnName("auth_islimit")
                    .HasComment("认证限制");

                entity.Property(e => e.AuthKeyPull)
                    .HasMaxLength(255)
                    .HasColumnName("auth_key_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("阿里云直播播流鉴权KEY");

                entity.Property(e => e.AuthKeyPush)
                    .HasMaxLength(255)
                    .HasColumnName("auth_key_push")
                    .HasDefaultValueSql("''")
                    .HasComment("阿里云直播推流鉴权KEY");

                entity.Property(e => e.AuthLengthPull)
                    .HasMaxLength(255)
                    .HasColumnName("auth_length_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("阿里云直播播流鉴权有效时长");

                entity.Property(e => e.AuthLengthPush)
                    .HasMaxLength(255)
                    .HasColumnName("auth_length_push")
                    .HasDefaultValueSql("''")
                    .HasComment("阿里云直播推流鉴权有效时长");

                entity.Property(e => e.BarrageFee)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("barrage_fee")
                    .HasDefaultValueSql("'1'")
                    .HasComment("弹幕费用");

                entity.Property(e => e.BonusSwitch)
                    .HasColumnName("bonus_switch")
                    .HasComment("登录奖励开关");

                entity.Property(e => e.CacheSwitch)
                    .HasColumnType("int(10)")
                    .HasColumnName("cache_switch")
                    .HasDefaultValueSql("'1'")
                    .HasComment("缓存开关");

                entity.Property(e => e.CacheTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("cache_time")
                    .HasDefaultValueSql("'60'")
                    .HasComment("缓存时间");

                entity.Property(e => e.CashEnd)
                    .HasColumnType("int(11)")
                    .HasColumnName("cash_end")
                    .HasComment("提现期限结束时间");

                entity.Property(e => e.CashMaxTimes)
                    .HasColumnType("int(11)")
                    .HasColumnName("cash_max_times")
                    .HasComment("提现最大次数");

                entity.Property(e => e.CashMin)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("cash_min")
                    .HasDefaultValueSql("'30'")
                    .HasComment("提现最低额度（元）");

                entity.Property(e => e.CashRate)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("cash_rate")
                    .HasDefaultValueSql("'32'")
                    .HasComment("提现比例");

                entity.Property(e => e.CashStart)
                    .HasColumnType("int(11)")
                    .HasColumnName("cash_start")
                    .HasComment("提现期限开始时间");

                entity.Property(e => e.CdnSwitch)
                    .IsRequired()
                    .HasColumnName("cdn_switch")
                    .HasDefaultValueSql("'1'")
                    .HasComment("cdn服务器选择 1表示阿里云 2表示腾讯云 3表示七牛云");

                entity.Property(e => e.Chatserver)
                    .HasMaxLength(255)
                    .HasColumnName("chatserver")
                    .HasComment("聊天服务器带端口");

                entity.Property(e => e.Cloudtype)
                    .HasColumnType("int(2)")
                    .HasColumnName("cloudtype")
                    .HasComment(" 存储方式：0本地 1七牛云存储 2腾讯云存储");

                entity.Property(e => e.CommentWeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("comment_weight")
                    .HasComment("评论权重值");

                entity.Property(e => e.Distribut1)
                    .HasColumnType("int(11)")
                    .HasColumnName("distribut1")
                    .HasComment("分销一级分成");

                entity.Property(e => e.Distribut2)
                    .HasColumnType("int(11)")
                    .HasColumnName("distribut2")
                    .HasComment("分销二级分成");

                entity.Property(e => e.Distribut3)
                    .HasColumnType("int(11)")
                    .HasColumnName("distribut3")
                    .HasComment("分销三级分成");

                entity.Property(e => e.FamilySwitch)
                    .HasColumnName("family_switch")
                    .HasComment("家族开关");

                entity.Property(e => e.GameBankerLimit)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_banker_limit")
                    .HasComment("上庄限制");

                entity.Property(e => e.GameOdds)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_odds")
                    .HasComment("游戏赔率");

                entity.Property(e => e.GameOddsP)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_odds_p")
                    .HasComment("系统坐庄游戏赔率");

                entity.Property(e => e.GameOddsU)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_odds_u")
                    .HasComment("用户坐庄游戏赔率");

                entity.Property(e => e.GamePump)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_pump")
                    .HasComment("游戏抽水");

                entity.Property(e => e.GameSwitch)
                    .HasMaxLength(255)
                    .HasColumnName("game_switch")
                    .HasDefaultValueSql("''")
                    .HasComment("游戏开关");

                entity.Property(e => e.HourMinusVal)
                    .HasColumnType("int(11)")
                    .HasColumnName("hour_minus_val")
                    .HasComment("每小时扣除曝光值");

                entity.Property(e => e.IhuyiAccount)
                    .HasMaxLength(255)
                    .HasColumnName("ihuyi_account")
                    .HasComment("互亿无线APIID");

                entity.Property(e => e.IhuyiPs)
                    .HasMaxLength(255)
                    .HasColumnName("ihuyi_ps")
                    .HasComment("互亿无线key");

                entity.Property(e => e.IosSandbox)
                    .HasColumnType("int(10)")
                    .HasColumnName("ios_sandbox")
                    .HasComment("苹果支付沙盒模式");

                entity.Property(e => e.IplimitSwitch)
                    .HasColumnName("iplimit_switch")
                    .HasComment("短信验证码IP限制开关");

                entity.Property(e => e.IplimitTimes)
                    .IsRequired()
                    .HasColumnName("iplimit_times")
                    .HasDefaultValueSql("'1'")
                    .HasComment("短信验证码IP限制次数");

                entity.Property(e => e.JpushKey)
                    .HasMaxLength(255)
                    .HasColumnName("jpush_key")
                    .HasComment("极光推送APP_KEY");

                entity.Property(e => e.JpushSandbox)
                    .HasColumnType("int(10)")
                    .HasColumnName("jpush_sandbox")
                    .HasComment("极光推送模式");

                entity.Property(e => e.JpushSecret)
                    .HasMaxLength(255)
                    .HasColumnName("jpush_secret")
                    .HasComment("极光推送master_secret");

                entity.Property(e => e.KickTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("kick_time")
                    .HasComment("踢出时长");

                entity.Property(e => e.LevelIslimit)
                    .HasColumnType("int(10)")
                    .HasColumnName("level_islimit")
                    .HasComment("直播等级控制");

                entity.Property(e => e.LevelLimit)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("level_limit")
                    .HasDefaultValueSql("'3'")
                    .HasComment("限制等级");

                entity.Property(e => e.LikeWeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("like_weight")
                    .HasComment("点赞权重值");

                entity.Property(e => e.LoginSinaPcAkey)
                    .HasMaxLength(255)
                    .HasColumnName("login_sina_pc_akey")
                    .HasComment("PC微博登陆akey");

                entity.Property(e => e.LoginSinaPcSkey)
                    .HasMaxLength(255)
                    .HasColumnName("login_sina_pc_skey")
                    .HasComment("PC新浪微博skey");

                entity.Property(e => e.LoginWxAppid)
                    .HasMaxLength(255)
                    .HasColumnName("login_wx_appid")
                    .HasDefaultValueSql("''")
                    .HasComment("微信公众平台应用ID");

                entity.Property(e => e.LoginWxAppsecret)
                    .HasMaxLength(255)
                    .HasColumnName("login_wx_appsecret")
                    .HasDefaultValueSql("''")
                    .HasComment("微信公众平台AppSecret");

                entity.Property(e => e.LoginWxPcAppid)
                    .HasMaxLength(255)
                    .HasColumnName("login_wx_pc_appid")
                    .HasComment("PC 微信登录appid");

                entity.Property(e => e.LoginWxPcAppsecret)
                    .HasMaxLength(255)
                    .HasColumnName("login_wx_pc_appsecret")
                    .HasComment("PC 微信登录appsecret");

                entity.Property(e => e.MicLimit)
                    .HasColumnType("int(11)")
                    .HasColumnName("mic_limit")
                    .HasComment("连麦等级限制，0表示无限制");

                entity.Property(e => e.PullUrl)
                    .HasMaxLength(255)
                    .HasColumnName("pull_url")
                    .HasComment("阿里云播流服务器地址");

                entity.Property(e => e.PushUrl)
                    .HasMaxLength(255)
                    .HasColumnName("push_url")
                    .HasComment("阿里云推流服务器地址");

                entity.Property(e => e.QiniuAccesskey)
                    .HasMaxLength(255)
                    .HasColumnName("qiniu_accesskey")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云存储accesskey");

                entity.Property(e => e.QiniuBucket)
                    .HasMaxLength(255)
                    .HasColumnName("qiniu_bucket")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛存储桶");

                entity.Property(e => e.QiniuDomain)
                    .HasMaxLength(255)
                    .HasColumnName("qiniu_domain")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛空间域名");

                entity.Property(e => e.QiniuDomainUrl)
                    .HasMaxLength(255)
                    .HasColumnName("qiniu_domain_url")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云空间绝对地址（app拼链接用）");

                entity.Property(e => e.QiniuSecretkey)
                    .HasMaxLength(255)
                    .HasColumnName("qiniu_secretkey")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云存储secretkey");

                entity.Property(e => e.QnAk)
                    .HasMaxLength(255)
                    .HasColumnName("qn_ak")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云AK");

                entity.Property(e => e.QnHname)
                    .HasMaxLength(255)
                    .HasColumnName("qn_hname")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云直播空间名称");

                entity.Property(e => e.QnPull)
                    .HasMaxLength(255)
                    .HasColumnName("qn_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云播流地址");

                entity.Property(e => e.QnPush)
                    .HasMaxLength(255)
                    .HasColumnName("qn_push")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云推流地址");

                entity.Property(e => e.QnSk)
                    .HasMaxLength(255)
                    .HasColumnName("qn_sk")
                    .HasDefaultValueSql("''")
                    .HasComment("七牛云SK");

                entity.Property(e => e.RegReward)
                    .HasColumnType("int(11)")
                    .HasColumnName("reg_reward")
                    .HasComment("注册奖励");

                entity.Property(e => e.SendcodeSwitch)
                    .HasColumnName("sendcode_switch")
                    .HasComment("短信验证码开关");

                entity.Property(e => e.ShareWeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("share_weight")
                    .HasComment("分享权重值");

                entity.Property(e => e.ShowVal)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_val")
                    .HasComment("初始曝光值");

                entity.Property(e => e.ShutTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("shut_time")
                    .HasComment("禁言时长");

                entity.Property(e => e.TxAppid)
                    .HasMaxLength(255)
                    .HasColumnName("tx_appid")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云直播appid");

                entity.Property(e => e.TxBizid)
                    .HasMaxLength(255)
                    .HasColumnName("tx_bizid")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云直播bizid");

                entity.Property(e => e.TxPull)
                    .HasMaxLength(255)
                    .HasColumnName("tx_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云直播播流域名");

                entity.Property(e => e.TxPush)
                    .HasMaxLength(255)
                    .HasColumnName("tx_push")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云直播推流域名");

                entity.Property(e => e.TxPushKey)
                    .HasMaxLength(255)
                    .HasColumnName("tx_push_key")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云直播推流防盗链Key");

                entity.Property(e => e.TxcloudAppid)
                    .HasMaxLength(255)
                    .HasColumnName("txcloud_appid")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云存储appid");

                entity.Property(e => e.TxcloudBucket)
                    .HasMaxLength(255)
                    .HasColumnName("txcloud_bucket")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云存储存储桶");

                entity.Property(e => e.TxcloudRegion)
                    .HasMaxLength(255)
                    .HasColumnName("txcloud_region")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云存储buctet所属地域 tj 华北 sh华东 gz 华南");

                entity.Property(e => e.TxcloudSecretId)
                    .HasMaxLength(255)
                    .HasColumnName("txcloud_secret_id")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云存储secret_id");

                entity.Property(e => e.TxcloudSecretKey)
                    .HasMaxLength(255)
                    .HasColumnName("txcloud_secret_key")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云存储secret_key");

                entity.Property(e => e.Tximgfolder)
                    .HasMaxLength(255)
                    .HasColumnName("tximgfolder")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云图片存放目录名称");

                entity.Property(e => e.Txuserimgfolder)
                    .HasMaxLength(255)
                    .HasColumnName("txuserimgfolder")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云用户头像存放目录名称");

                entity.Property(e => e.Txvideofolder)
                    .HasMaxLength(255)
                    .HasColumnName("txvideofolder")
                    .HasDefaultValueSql("''")
                    .HasComment("腾讯云视频存放目录名称");

                entity.Property(e => e.UmApikey)
                    .HasMaxLength(255)
                    .HasColumnName("um_apikey")
                    .HasDefaultValueSql("''")
                    .HasComment("友盟OpenApi-apiKey");

                entity.Property(e => e.UmApisecurity)
                    .HasMaxLength(255)
                    .HasColumnName("um_apisecurity")
                    .HasDefaultValueSql("''")
                    .HasComment("友盟OpenApi-apiSecurity");

                entity.Property(e => e.UmAppkeyAndroid)
                    .HasMaxLength(255)
                    .HasColumnName("um_appkey_android")
                    .HasDefaultValueSql("''")
                    .HasComment("友盟Android应用-appkey");

                entity.Property(e => e.UmAppkeyIos)
                    .HasMaxLength(255)
                    .HasColumnName("um_appkey_ios")
                    .HasDefaultValueSql("''")
                    .HasComment("友盟IOS应用-appkey");

                entity.Property(e => e.UserlistTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("userlist_time")
                    .HasDefaultValueSql("'60'")
                    .HasComment("用户列表请求间隔");

                entity.Property(e => e.VideoAuditSwitch)
                    .HasColumnName("video_audit_switch")
                    .HasComment("视频审核开关");

                entity.Property(e => e.VideoShowtype)
                    .HasColumnName("video_showtype")
                    .HasComment("推荐视频显示方式");

                entity.Property(e => e.WsApn)
                    .HasMaxLength(255)
                    .HasColumnName("ws_apn")
                    .HasDefaultValueSql("''")
                    .HasComment("网宿AppName");

                entity.Property(e => e.WsPull)
                    .HasMaxLength(255)
                    .HasColumnName("ws_pull")
                    .HasDefaultValueSql("''")
                    .HasComment("网宿播流地址");

                entity.Property(e => e.WsPush)
                    .HasMaxLength(255)
                    .HasColumnName("ws_push")
                    .HasDefaultValueSql("''")
                    .HasComment("网宿推流地址");

                entity.Property(e => e.WxAppid)
                    .HasMaxLength(255)
                    .HasColumnName("wx_appid")
                    .HasComment("开放平台账号AppID");

                entity.Property(e => e.WxAppsecret)
                    .HasMaxLength(255)
                    .HasColumnName("wx_appsecret")
                    .HasComment("微信应用appsecret");

                entity.Property(e => e.WxKey)
                    .HasMaxLength(255)
                    .HasColumnName("wx_key")
                    .HasComment("微信密钥key");

                entity.Property(e => e.WxMchid)
                    .HasMaxLength(255)
                    .HasColumnName("wx_mchid")
                    .HasComment("微信商户号mchid");

                entity.Property(e => e.WxSwitch)
                    .HasColumnType("int(10)")
                    .HasColumnName("wx_switch")
                    .HasDefaultValueSql("'1'")
                    .HasComment("微信支付");

                entity.Property(e => e.WxSwitchPc)
                    .HasColumnType("int(10)")
                    .HasColumnName("wx_switch_pc")
                    .HasComment("微信支付PC");

                entity.Property(e => e.WyAppkey)
                    .HasMaxLength(255)
                    .HasColumnName("wy_appkey")
                    .HasDefaultValueSql("''")
                    .HasComment("网易appkey");

                entity.Property(e => e.WyAppsecret)
                    .HasMaxLength(255)
                    .HasColumnName("wy_appsecret")
                    .HasComment("网易appSecret");
            });

            modelBuilder.Entity<CmfDefaultAvatar>(entity =>
            {
                entity.ToTable("cmf_default_avatar");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(6) unsigned")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(100)
                    .HasColumnName("avatar_url")
                    .HasDefaultValueSql("''")
                    .HasComment("头像文件路径");

                entity.Property(e => e.LastUpdatetime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_updatetime")
                    .HasComment("最后修改时间");
            });

            modelBuilder.Entity<CmfDynamic>(entity =>
            {
                entity.ToTable("cmf_dynamic");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''")
                    .HasComment("详细地理位置");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("发布时间");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Comments)
                    .HasColumnType("int(11)")
                    .HasColumnName("comments")
                    .HasComment("评论数");

                entity.Property(e => e.FailReason)
                    .HasMaxLength(255)
                    .HasColumnName("fail_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("审核原因");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("视频地址");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("是否删除 1删除（下架）0不下架");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("维度");

                entity.Property(e => e.Length)
                    .HasColumnType("int(11)")
                    .HasColumnName("length")
                    .HasDefaultValueSql("'0'")
                    .HasComment("语音时长");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasComment("点赞数");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.RecommendVal)
                    .HasColumnType("int(20)")
                    .HasColumnName("recommend_val")
                    .HasDefaultValueSql("'0'")
                    .HasComment("推荐值");

                entity.Property(e => e.ShowVal)
                    .HasColumnType("int(12)")
                    .HasColumnName("show_val")
                    .HasComment("曝光值");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("视频状态 0未审核 1通过 2拒绝");

                entity.Property(e => e.Thumb)
                    .HasColumnType("text")
                    .HasColumnName("thumb")
                    .HasComment("图片地址：多张图片用分号隔开");

                entity.Property(e => e.ThumbArs)
                    .HasColumnType("text")
                    .HasColumnName("thumb_ars");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnType("int(10)")
                    .HasColumnName("type")
                    .HasComment("动态类型：0：纯文字；1：文字+图片；2：文字+视频；3：文字+语音");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(12)")
                    .HasColumnName("uptime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）");

                entity.Property(e => e.VideoThumb)
                    .HasMaxLength(255)
                    .HasColumnName("video_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("视频封面");

                entity.Property(e => e.Voice)
                    .HasMaxLength(255)
                    .HasColumnName("voice")
                    .HasDefaultValueSql("''")
                    .HasComment("语音链接");

                entity.Property(e => e.XiajiaReason)
                    .HasMaxLength(255)
                    .HasColumnName("xiajia_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("下架原因");
            });

            modelBuilder.Entity<CmfDynamicComment>(entity =>
            {
                entity.ToTable("cmf_dynamic_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasComment("评论iD");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("评论内容");

                entity.Property(e => e.Dynamicid)
                    .HasColumnType("int(10)")
                    .HasColumnName("dynamicid")
                    .HasComment("动态ID");

                entity.Property(e => e.Length)
                    .HasColumnType("int(11)")
                    .HasColumnName("length")
                    .HasComment("时长");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasComment("点赞数");

                entity.Property(e => e.Parentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("parentid")
                    .HasComment("上级评论ID");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(10)")
                    .HasColumnName("touid")
                    .HasComment("被评论用户ID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型，0文字1语音");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("评论用户ID");

                entity.Property(e => e.Voice)
                    .HasMaxLength(255)
                    .HasColumnName("voice")
                    .HasDefaultValueSql("''")
                    .HasComment("语音链接");
            });

            modelBuilder.Entity<CmfDynamicCommentsLike>(entity =>
            {
                entity.ToTable("cmf_dynamic_comments_like");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasComment("评论ID");

                entity.Property(e => e.Dynamicid)
                    .HasColumnType("int(12)")
                    .HasColumnName("dynamicid")
                    .HasComment("评论所属动态id");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("被喜欢的评论者id");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("点赞用户ID");
            });

            modelBuilder.Entity<CmfDynamicLike>(entity =>
            {
                entity.ToTable("cmf_dynamic_like");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("点赞时间");

                entity.Property(e => e.Dynamicid)
                    .HasColumnType("int(10)")
                    .HasColumnName("dynamicid")
                    .HasComment("动态id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("动态是否被删除或被拒绝 0被删除或被拒绝 1 正常");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("点赞用户");
            });

            modelBuilder.Entity<CmfDynamicReport>(entity =>
            {
                entity.ToTable("cmf_dynamic_report");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("举报内容");

                entity.Property(e => e.DynamicType)
                    .HasColumnType("int(10)")
                    .HasColumnName("dynamic_type")
                    .HasComment("动态类型：0：纯文字；1：文字+图片‘；2：视频+图片；3：语音+图片");

                entity.Property(e => e.Dynamicid)
                    .HasColumnType("int(11)")
                    .HasColumnName("dynamicid")
                    .HasComment("动态ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("0处理中 1已处理  2审核失败");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("被举报用户ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("举报用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfDynamicReportClassify>(entity =>
            {
                entity.ToTable("cmf_dynamic_report_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(10)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("举报类型名称")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");
            });

            modelBuilder.Entity<CmfExperlevel>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Levelid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("cmf_experlevel");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Levelid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("levelid")
                    .HasComment("等级");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Bg)
                    .HasMaxLength(255)
                    .HasColumnName("bg")
                    .HasDefaultValueSql("''")
                    .HasComment("背景");

                entity.Property(e => e.Colour)
                    .HasMaxLength(255)
                    .HasColumnName("colour")
                    .HasDefaultValueSql("''")
                    .HasComment("昵称颜色");

                entity.Property(e => e.LevelUp)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("level_up")
                    .HasComment("经验上限");

                entity.Property(e => e.Levelname)
                    .HasMaxLength(50)
                    .HasColumnName("levelname")
                    .HasDefaultValueSql("''")
                    .HasComment("等级名称");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("标识");

                entity.Property(e => e.ThumbMark)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_mark")
                    .HasDefaultValueSql("''")
                    .HasComment("头像角标");
            });

            modelBuilder.Entity<CmfExperlevelAnchor>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Levelid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("cmf_experlevel_anchor");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Levelid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("levelid")
                    .HasComment("等级");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.Bg)
                    .HasMaxLength(255)
                    .HasColumnName("bg")
                    .HasDefaultValueSql("''")
                    .HasComment("背景");

                entity.Property(e => e.LevelUp)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("level_up")
                    .HasDefaultValueSql("'0'")
                    .HasComment("等级上限");

                entity.Property(e => e.Levelname)
                    .HasMaxLength(50)
                    .HasColumnName("levelname")
                    .HasDefaultValueSql("''")
                    .HasComment("等级名称");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("标识");

                entity.Property(e => e.ThumbMark)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_mark")
                    .HasDefaultValueSql("''")
                    .HasComment("头像角标");
            });

            modelBuilder.Entity<CmfFamily>(entity =>
            {
                entity.ToTable("cmf_family");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.ApplyPos)
                    .HasMaxLength(255)
                    .HasColumnName("apply_pos")
                    .HasDefaultValueSql("''")
                    .HasComment("身份证正面");

                entity.Property(e => e.ApplySide)
                    .HasMaxLength(255)
                    .HasColumnName("apply_side")
                    .HasDefaultValueSql("''")
                    .HasComment("身份证背面");

                entity.Property(e => e.Badge)
                    .HasMaxLength(255)
                    .HasColumnName("badge")
                    .HasDefaultValueSql("''")
                    .HasComment("家族图标");

                entity.Property(e => e.Briefing)
                    .HasColumnType("text")
                    .HasColumnName("briefing")
                    .HasComment("简介");

                entity.Property(e => e.Carded)
                    .HasMaxLength(255)
                    .HasColumnName("carded")
                    .HasDefaultValueSql("''")
                    .HasComment("证件号");

                entity.Property(e => e.Disable)
                    .HasColumnName("disable")
                    .HasComment("是否禁用");

                entity.Property(e => e.DivideFamily)
                    .HasColumnType("int(11)")
                    .HasColumnName("divide_family")
                    .HasComment("分成比例");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Istip)
                    .HasColumnName("istip")
                    .HasComment("是否需要通知");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("家族名称");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason")
                    .HasDefaultValueSql("''")
                    .HasComment("失败原因");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasComment("申请状态 0未审核 1 审核失败 2 审核通过 3");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfFamilyProfit>(entity =>
            {
                entity.ToTable("cmf_family_profit");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Familyid)
                    .HasColumnType("int(11)")
                    .HasColumnName("familyid")
                    .HasComment("家族ID");

                entity.Property(e => e.Profit)
                    .HasPrecision(20, 2)
                    .HasColumnName("profit")
                    .HasComment("家族收益");

                entity.Property(e => e.ProfitAnthor)
                    .HasPrecision(20, 2)
                    .HasColumnName("profit_anthor")
                    .HasComment("主播收益");

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .HasColumnName("time")
                    .HasDefaultValueSql("''")
                    .HasComment("格式化日期");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasComment("总收益");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("主播ID");
            });

            modelBuilder.Entity<CmfFamilyUser>(entity =>
            {
                entity.ToTable("cmf_family_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.DivideFamily)
                    .HasColumnType("int(11)")
                    .HasColumnName("divide_family")
                    .HasDefaultValueSql("'-1'")
                    .HasComment("家族分成");

                entity.Property(e => e.Familyid)
                    .HasColumnType("int(11)")
                    .HasColumnName("familyid")
                    .HasComment("家族ID");

                entity.Property(e => e.Istip)
                    .HasColumnName("istip")
                    .HasComment("审核后是否需要通知");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason")
                    .HasDefaultValueSql("''")
                    .HasComment("原因");

                entity.Property(e => e.Signout)
                    .HasColumnName("signout")
                    .HasComment("是否退出");

                entity.Property(e => e.SignoutIstip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("signout_istip")
                    .HasComment("踢出或拒绝是否需要通知");

                entity.Property(e => e.SignoutReason)
                    .HasMaxLength(255)
                    .HasColumnName("signout_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("踢出或拒绝理由");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasComment("状态");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfFamilyUserDivideApply>(entity =>
            {
                entity.ToTable("cmf_family_user_divide_apply");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Divide)
                    .HasColumnType("int(11)")
                    .HasColumnName("divide")
                    .HasComment("家族分成");

                entity.Property(e => e.Familyid)
                    .HasColumnType("int(11)")
                    .HasColumnName("familyid")
                    .HasComment("家族id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("处理状态 0 等待审核 1 同意 -1 拒绝");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户id");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<CmfFeedback>(entity =>
            {
                entity.ToTable("cmf_feedback");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("内容");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .HasColumnName("model")
                    .HasDefaultValueSql("''")
                    .HasComment("设备");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图片");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''")
                    .HasComment("系统版本号");
            });

            modelBuilder.Entity<CmfGame>(entity =>
            {
                entity.ToTable("cmf_game");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏名称");

                entity.Property(e => e.BankerCard)
                    .HasMaxLength(50)
                    .HasColumnName("banker_card")
                    .HasDefaultValueSql("''")
                    .HasComment("庄家牌型");

                entity.Property(e => e.BankerProfit)
                    .HasColumnType("int(11)")
                    .HasColumnName("banker_profit")
                    .HasDefaultValueSql("'0'")
                    .HasComment("庄家收益");

                entity.Property(e => e.Bankerid)
                    .HasColumnType("int(11)")
                    .HasColumnName("bankerid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("庄家ID，0表示平台");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏结束时间");

                entity.Property(e => e.Isintervene)
                    .HasColumnName("isintervene")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否进行系统干预");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("主播ID");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .HasColumnName("result")
                    .HasDefaultValueSql("'0'")
                    .HasComment("本轮游戏结果");

                entity.Property(e => e.Starttime)
                    .HasColumnType("int(11)")
                    .HasColumnName("starttime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("本次游戏开始时间");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("'0'")
                    .HasComment("当前游戏状态（0是进行中，1是正常结束，2是 主播关闭 3意外结束）");

                entity.Property(e => e.Stream)
                    .HasMaxLength(255)
                    .HasColumnName("stream")
                    .HasDefaultValueSql("''")
                    .HasComment("直播流名");
            });

            modelBuilder.Entity<CmfGamerecord>(entity =>
            {
                entity.ToTable("cmf_gamerecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏类型");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("下注时间");

                entity.Property(e => e.Coin1)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_1")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1位置下注金额");

                entity.Property(e => e.Coin2)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_2")
                    .HasDefaultValueSql("'0'")
                    .HasComment("2位置下注金额");

                entity.Property(e => e.Coin3)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_3")
                    .HasDefaultValueSql("'0'")
                    .HasComment("3位置下注金额");

                entity.Property(e => e.Coin4)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_4")
                    .HasDefaultValueSql("'0'")
                    .HasComment("4位置下注金额");

                entity.Property(e => e.Coin5)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_5")
                    .HasDefaultValueSql("'0'")
                    .HasComment("5位置下注金额");

                entity.Property(e => e.Coin6)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_6")
                    .HasDefaultValueSql("'0'")
                    .HasComment("6位置下注金额");

                entity.Property(e => e.Gameid)
                    .HasColumnType("int(11)")
                    .HasColumnName("gameid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏ID");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("主播ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("处理状态 0 未处理 1 已处理");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfGetcodeLimitIp>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_getcode_limit_ip");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ip)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever()
                    .HasColumnName("ip")
                    .HasComment("ip地址");

                entity.Property(e => e.Date)
                    .HasMaxLength(30)
                    .HasColumnName("date")
                    .HasDefaultValueSql("''")
                    .HasComment("时间");

                entity.Property(e => e.Times)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("times")
                    .HasComment("次数");
            });

            modelBuilder.Entity<CmfGift>(entity =>
            {
                entity.ToTable("cmf_gift");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Gifticon)
                    .HasMaxLength(255)
                    .HasColumnName("gifticon")
                    .HasDefaultValueSql("''")
                    .HasComment("图片");

                entity.Property(e => e.Giftname)
                    .HasMaxLength(50)
                    .HasColumnName("giftname")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.GiftnameEn)
                    .HasMaxLength(255)
                    .HasColumnName("giftname_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.GiftnameNam)
                    .HasMaxLength(255)
                    .HasColumnName("giftname_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Isplatgift)
                    .HasColumnName("isplatgift")
                    .HasComment("是否全站礼物：0：否；1：是");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(3)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Mark)
                    .HasColumnName("mark")
                    .HasComment("标识，0普通，1热门，2守护");

                entity.Property(e => e.Needcoin)
                    .HasColumnType("int(11)")
                    .HasColumnName("needcoin")
                    .HasComment("价格");

                entity.Property(e => e.Sid)
                    .HasColumnType("int(11)")
                    .HasColumnName("sid")
                    .HasComment("分类ID");

                entity.Property(e => e.StickerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sticker_id")
                    .HasComment("贴纸ID");

                entity.Property(e => e.Swf)
                    .HasMaxLength(255)
                    .HasColumnName("swf")
                    .HasDefaultValueSql("''")
                    .HasComment("动画链接");

                entity.Property(e => e.Swftime)
                    .HasPrecision(10, 2)
                    .HasColumnName("swftime")
                    .HasComment("动画时长");

                entity.Property(e => e.Swftype)
                    .HasColumnName("swftype")
                    .HasComment("动画类型，0gif,1svga");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("类型,0普通礼物，1豪华礼物");
            });

            modelBuilder.Entity<CmfGiftLuckRate>(entity =>
            {
                entity.ToTable("cmf_gift_luck_rate");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(11)")
                    .HasColumnName("giftid")
                    .HasComment("礼物ID");

                entity.Property(e => e.Isall)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("isall")
                    .HasComment("是否全站，0否1是");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Rate)
                    .HasPrecision(20, 3)
                    .HasColumnName("rate")
                    .HasComment("中奖概率");

                entity.Property(e => e.Times)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("times")
                    .HasComment("倍数");
            });

            modelBuilder.Entity<CmfGiftSort>(entity =>
            {
                entity.ToTable("cmf_gift_sort");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(3)")
                    .HasColumnName("orderno")
                    .HasComment("序号");

                entity.Property(e => e.Sortname)
                    .HasMaxLength(20)
                    .HasColumnName("sortname")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名");
            });

            modelBuilder.Entity<CmfGuard>(entity =>
            {
                entity.ToTable("cmf_guard");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("价格");

                entity.Property(e => e.Length)
                    .HasColumnType("int(11)")
                    .HasColumnName("length")
                    .HasComment("时长");

                entity.Property(e => e.LengthTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("length_time")
                    .HasComment("时长秒数");

                entity.Property(e => e.LengthType)
                    .HasColumnName("length_type")
                    .HasComment("时长类型，0天，1月，2年");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("守护名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("守护类型，1普通2尊贵");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfGuardUser>(entity =>
            {
                entity.ToTable("cmf_guard_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Liveuid, "liveuid_index");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("守护类型,1普通守护，2尊贵守护");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfGuardUser1>(entity =>
            {
                entity.ToTable("cmf_guard_users");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Liveuid, "liveuid_index");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("守护类型,1普通守护，2尊贵守护");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfGuide>(entity =>
            {
                entity.ToTable("cmf_guide");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("跳转链接");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("序号");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图片/视频链接");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfHook>(entity =>
            {
                entity.ToTable("cmf_hook");

                entity.HasComment("系统钩子表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.App)
                    .HasMaxLength(15)
                    .HasColumnName("app")
                    .HasDefaultValueSql("''")
                    .HasComment("应用名(只有应用钩子才用)");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("描述");

                entity.Property(e => e.Hook)
                    .HasMaxLength(50)
                    .HasColumnName("hook")
                    .HasDefaultValueSql("''")
                    .HasComment("钩子");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("钩子名称");

                entity.Property(e => e.Once)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("once")
                    .HasComment("是否只允许一个插件运行(0:多个;1:一个)");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("type")
                    .HasComment("钩子类型(1:系统钩子;2:应用钩子;3:模板钩子;4:后台模板钩子)");
            });

            modelBuilder.Entity<CmfHookPlugin>(entity =>
            {
                entity.ToTable("cmf_hook_plugin");

                entity.HasComment("系统钩子插件表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Hook)
                    .HasMaxLength(50)
                    .HasColumnName("hook")
                    .HasDefaultValueSql("''")
                    .HasComment("钩子名");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Plugin)
                    .HasMaxLength(50)
                    .HasColumnName("plugin")
                    .HasDefaultValueSql("''")
                    .HasComment("插件");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态(0:禁用,1:启用)");
            });

            modelBuilder.Entity<CmfImpressionLabel>(entity =>
            {
                entity.ToTable("cmf_impression_label");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Colour)
                    .HasMaxLength(255)
                    .HasColumnName("colour")
                    .HasDefaultValueSql("''")
                    .HasComment("颜色");

                entity.Property(e => e.Colour2)
                    .HasMaxLength(255)
                    .HasColumnName("colour2")
                    .HasDefaultValueSql("''")
                    .HasComment("尾色");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("标签名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(11)")
                    .HasColumnName("orderno")
                    .HasComment("序号");
            });

            modelBuilder.Entity<CmfInstruction>(entity =>
            {
                entity.ToTable("cmf_instructions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AddDesc)
                    .HasColumnType("text")
                    .HasColumnName("add_desc")
                    .HasComment("说明");
            });

            modelBuilder.Entity<CmfJackpot>(entity =>
            {
                entity.ToTable("cmf_jackpot");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Level)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("level")
                    .HasComment("奖池等级");

                entity.Property(e => e.Total)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("total")
                    .HasComment("奖池金额");
            });

            modelBuilder.Entity<CmfJackpotLevel>(entity =>
            {
                entity.ToTable("cmf_jackpot_level");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.LevelUp)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("level_up")
                    .HasComment("经验下限");

                entity.Property(e => e.Levelid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("levelid")
                    .HasComment("等级");
            });

            modelBuilder.Entity<CmfJackpotRate>(entity =>
            {
                entity.ToTable("cmf_jackpot_rate");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(11)")
                    .HasColumnName("giftid")
                    .HasComment("礼物ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.RateJackpot)
                    .HasColumnType("text")
                    .HasColumnName("rate_jackpot")
                    .HasComment("奖池概率");
            });

            modelBuilder.Entity<CmfLabel>(entity =>
            {
                entity.ToTable("cmf_label");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Colour)
                    .HasMaxLength(255)
                    .HasColumnName("colour")
                    .HasDefaultValueSql("''")
                    .HasComment("颜色");

                entity.Property(e => e.Colour2)
                    .HasMaxLength(255)
                    .HasColumnName("colour2")
                    .HasDefaultValueSql("''")
                    .HasComment("尾色");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("标签名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");
            });

            modelBuilder.Entity<CmfLabelUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_label_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Touid, "touid");

                entity.HasIndex(e => e.Uid, "uid");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Label)
                    .HasMaxLength(255)
                    .HasColumnName("label")
                    .HasDefaultValueSql("''")
                    .HasComment("选择的标签");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfLevel>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Levelid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("cmf_level");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Levelid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("levelid")
                    .HasComment("等级");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Bg)
                    .HasMaxLength(255)
                    .HasColumnName("bg")
                    .HasDefaultValueSql("''")
                    .HasComment("背景");

                entity.Property(e => e.Colour)
                    .HasMaxLength(255)
                    .HasColumnName("colour")
                    .HasDefaultValueSql("''")
                    .HasComment("昵称颜色");

                entity.Property(e => e.LevelUp)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("level_up")
                    .HasComment("经验上限");

                entity.Property(e => e.Levelname)
                    .HasMaxLength(50)
                    .HasColumnName("levelname")
                    .HasDefaultValueSql("''")
                    .HasComment("等级名称");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("标识");

                entity.Property(e => e.ThumbMark)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_mark")
                    .HasDefaultValueSql("''")
                    .HasComment("头像角标");
            });

            modelBuilder.Entity<CmfLevelAnchor>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Levelid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("cmf_level_anchor");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Levelid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("levelid")
                    .HasComment("等级");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.Bg)
                    .HasMaxLength(255)
                    .HasColumnName("bg")
                    .HasDefaultValueSql("''")
                    .HasComment("背景");

                entity.Property(e => e.LevelUp)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("level_up")
                    .HasDefaultValueSql("'0'")
                    .HasComment("等级上限");

                entity.Property(e => e.Levelname)
                    .HasMaxLength(50)
                    .HasColumnName("levelname")
                    .HasDefaultValueSql("''")
                    .HasComment("等级名称");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("标识");

                entity.Property(e => e.ThumbMark)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_mark")
                    .HasDefaultValueSql("''")
                    .HasComment("头像角标");
            });

            modelBuilder.Entity<CmfLiang>(entity =>
            {
                entity.ToTable("cmf_liang");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Buytime)
                    .HasColumnType("int(11)")
                    .HasColumnName("buytime")
                    .HasComment("购买时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("价格");

                entity.Property(e => e.Length)
                    .HasColumnType("int(11)")
                    .HasColumnName("length")
                    .HasComment("长度");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("靓号");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("积分价格");

                entity.Property(e => e.State)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("state")
                    .HasComment("启用状态");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("靓号销售状态");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("购买用户ID");
            });

            modelBuilder.Entity<CmfLink>(entity =>
            {
                entity.ToTable("cmf_link");

                entity.HasComment("友情链接表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Status, "status");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接描述");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接图标");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rating)
                    .HasColumnType("int(11)")
                    .HasColumnName("rating")
                    .HasComment("友情链接评级");

                entity.Property(e => e.Rel)
                    .HasMaxLength(50)
                    .HasColumnName("rel")
                    .HasDefaultValueSql("''")
                    .HasComment("链接与网站的关系");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:显示;0:不显示");

                entity.Property(e => e.Target)
                    .HasMaxLength(10)
                    .HasColumnName("target")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接打开方式");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接地址");
            });

            modelBuilder.Entity<CmfLink1>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_links");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.LinkStatus, "link_visible");

                entity.Property(e => e.LinkId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("link_id");

                entity.Property(e => e.LinkDescription)
                    .HasColumnType("text")
                    .HasColumnName("link_description")
                    .HasComment("友情链接描述");

                entity.Property(e => e.LinkImage)
                    .HasMaxLength(255)
                    .HasColumnName("link_image")
                    .HasComment("友情链接图标");

                entity.Property(e => e.LinkName)
                    .HasMaxLength(255)
                    .HasColumnName("link_name")
                    .HasComment("友情链接名称");

                entity.Property(e => e.LinkRating)
                    .HasColumnType("int(11)")
                    .HasColumnName("link_rating")
                    .HasComment("友情链接评级");

                entity.Property(e => e.LinkRel)
                    .HasMaxLength(255)
                    .HasColumnName("link_rel")
                    .HasComment("链接与网站的关系");

                entity.Property(e => e.LinkStatus)
                    .HasColumnType("int(2)")
                    .HasColumnName("link_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1显示，0不显示");

                entity.Property(e => e.LinkTarget)
                    .HasMaxLength(25)
                    .HasColumnName("link_target")
                    .HasDefaultValueSql("'_blank'")
                    .HasComment("友情链接打开方式");

                entity.Property(e => e.LinkUrl)
                    .HasMaxLength(255)
                    .HasColumnName("link_url")
                    .HasComment("友情链接地址");

                entity.Property(e => e.Listorder)
                    .HasColumnType("int(10)")
                    .HasColumnName("listorder")
                    .HasComment("排序");
            });

            modelBuilder.Entity<CmfLive>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_live");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Islive, e.Starttime }, "index_islive_starttime");

                entity.HasIndex(e => new { e.Uid, e.Stream }, "index_uid_stream")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 191 });

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Anyway)
                    .IsRequired()
                    .HasColumnName("anyway")
                    .HasDefaultValueSql("'1'")
                    .HasComment("横竖屏，0表示竖屏，1表示横屏");

                entity.Property(e => e.BankerCoin)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("banker_coin")
                    .HasDefaultValueSql("'0'")
                    .HasComment("庄家余额");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Deviceinfo)
                    .HasMaxLength(255)
                    .HasColumnName("deviceinfo")
                    .HasDefaultValueSql("''")
                    .HasComment("设备信息");

                entity.Property(e => e.GameAction)
                    .HasColumnName("game_action")
                    .HasComment("游戏类型");

                entity.Property(e => e.Goodnum)
                    .HasMaxLength(255)
                    .HasColumnName("goodnum")
                    .HasDefaultValueSql("'0'")
                    .HasComment("靓号");

                entity.Property(e => e.Hotvotes)
                    .HasColumnType("int(11)")
                    .HasColumnName("hotvotes")
                    .HasComment("热门礼物总额");

                entity.Property(e => e.Ishot)
                    .HasColumnName("ishot")
                    .HasComment("是否热门");

                entity.Property(e => e.Islive)
                    .HasColumnType("int(1)")
                    .HasColumnName("islive")
                    .HasComment("直播状态");

                entity.Property(e => e.Ismic)
                    .HasColumnName("ismic")
                    .HasComment("连麦开关，0是关，1是开");

                entity.Property(e => e.Isoff)
                    .HasColumnName("isoff")
                    .HasComment("是否断流，0否1是");

                entity.Property(e => e.Isrecommend)
                    .HasColumnName("isrecommend")
                    .HasComment("是否推荐");

                entity.Property(e => e.Isshop)
                    .HasColumnName("isshop")
                    .HasComment("是否开启店铺");

                entity.Property(e => e.Isvideo)
                    .HasColumnName("isvideo")
                    .HasComment("是否假视频");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("维度");

                entity.Property(e => e.Liveclassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveclassid")
                    .HasComment("直播分类ID");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.Offtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("offtime")
                    .HasComment("断流时间");

                entity.Property(e => e.Pkstream)
                    .HasMaxLength(255)
                    .HasColumnName("pkstream")
                    .HasDefaultValueSql("''")
                    .HasComment("pk对方的流名");

                entity.Property(e => e.Pkuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("pkuid")
                    .HasComment("PK对方ID");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Pull)
                    .HasMaxLength(255)
                    .HasColumnName("pull")
                    .HasDefaultValueSql("''")
                    .HasComment("播流地址");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(12)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Starttime)
                    .HasColumnType("int(12)")
                    .HasColumnName("starttime")
                    .HasComment("开播时间");

                entity.Property(e => e.Stream)
                    .HasColumnName("stream")
                    .HasDefaultValueSql("''")
                    .HasComment("流名");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("直播类型");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("''")
                    .HasComment("类型值");

                entity.Property(e => e.WyCid)
                    .HasMaxLength(255)
                    .HasColumnName("wy_cid")
                    .HasDefaultValueSql("''")
                    .HasComment("网易房间ID(当不使用网易是默认为空)");
            });

            modelBuilder.Entity<CmfLiveBan>(entity =>
            {
                entity.HasKey(e => e.Liveuid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_live_ban");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Superid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("superid")
                    .HasComment("超管ID");
            });

            modelBuilder.Entity<CmfLiveClass>(entity =>
            {
                entity.ToTable("cmf_live_class");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Des)
                    .HasMaxLength(255)
                    .HasColumnName("des")
                    .HasDefaultValueSql("''")
                    .HasComment("描述");

                entity.Property(e => e.En)
                    .HasMaxLength(255)
                    .HasColumnName("en");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Nam)
                    .HasMaxLength(255)
                    .HasColumnName("nam");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图标");
            });

            modelBuilder.Entity<CmfLiveKick>(entity =>
            {
                entity.ToTable("cmf_live_kick");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Actionid)
                    .HasColumnType("int(11)")
                    .HasColumnName("actionid")
                    .HasComment("操作用户ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfLiveManager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_live_manager");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Liveuid, e.Uid }, "uid_touid_index");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(12)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfLiveRecord>(entity =>
            {
                entity.ToTable("cmf_live_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Starttime }, "index_uid_start");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("结束时间");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("纬度");

                entity.Property(e => e.Liveclassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveclassid")
                    .HasComment("直播分类ID");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("关播时人数");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(11)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Starttime)
                    .HasColumnType("int(11)")
                    .HasColumnName("starttime")
                    .HasComment("开始时间");

                entity.Property(e => e.Stream)
                    .HasMaxLength(255)
                    .HasColumnName("stream")
                    .HasDefaultValueSql("''")
                    .HasComment("流名");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图");

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .HasColumnName("time")
                    .HasDefaultValueSql("''")
                    .HasComment("格式日期");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("直播类型");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("''")
                    .HasComment("类型值");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(255)
                    .HasColumnName("video_url")
                    .HasDefaultValueSql("''")
                    .HasComment("回放地址");

                entity.Property(e => e.Votes)
                    .HasMaxLength(255)
                    .HasColumnName("votes")
                    .HasDefaultValueSql("'0'")
                    .HasComment("本次直播收益");
            });

            modelBuilder.Entity<CmfLiveShut>(entity =>
            {
                entity.ToTable("cmf_live_shut");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Actionid)
                    .HasColumnType("int(11)")
                    .HasColumnName("actionid")
                    .HasComment("操作者ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("showid")
                    .HasComment("禁言类型，0永久");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfLoginbonu>(entity =>
            {
                entity.ToTable("cmf_loginbonus");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(10)")
                    .HasColumnName("coin")
                    .HasComment("登录奖励");

                entity.Property(e => e.Day)
                    .HasColumnType("int(10)")
                    .HasColumnName("day")
                    .HasComment("登录天数");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(10)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfLuckRate>(entity =>
            {
                entity.ToTable("cmf_luck_rate");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(11)")
                    .HasColumnName("giftid")
                    .HasComment("礼物ID");

                entity.Property(e => e.Isall)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("isall")
                    .HasComment("是否全站，0否1是");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Rate)
                    .HasPrecision(20, 3)
                    .HasColumnName("rate")
                    .HasComment("中奖概率");

                entity.Property(e => e.Times)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("times")
                    .HasComment("倍数");
            });

            modelBuilder.Entity<CmfMenu>(entity =>
            {
                entity.ToTable("cmf_menu");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Model, "model");

                entity.HasIndex(e => e.Parentid, "parentid");

                entity.HasIndex(e => e.Status, "status");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(6) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action")
                    .IsFixedLength()
                    .HasComment("操作名称");

                entity.Property(e => e.App)
                    .HasMaxLength(20)
                    .HasColumnName("app")
                    .IsFixedLength()
                    .HasComment("应用名称app");

                entity.Property(e => e.Data)
                    .HasMaxLength(50)
                    .HasColumnName("data")
                    .IsFixedLength()
                    .HasComment("额外参数");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .HasColumnName("icon")
                    .HasComment("菜单图标");

                entity.Property(e => e.Listorder)
                    .HasColumnType("smallint(6) unsigned")
                    .HasColumnName("listorder")
                    .HasComment("排序ID");

                entity.Property(e => e.Model)
                    .HasMaxLength(20)
                    .HasColumnName("model")
                    .IsFixedLength()
                    .HasComment("控制器");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("菜单名称");

                entity.Property(e => e.Parentid)
                    .HasColumnType("smallint(6) unsigned")
                    .HasColumnName("parentid");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark")
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasColumnName("status")
                    .HasComment("状态，1显示，0不显示");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("菜单类型  1：权限认证+菜单；0：只作为菜单");
            });

            modelBuilder.Entity<CmfMusic>(entity =>
            {
                entity.ToTable("cmf_music");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .HasColumnName("author")
                    .HasDefaultValueSql("''")
                    .HasComment("演唱者");

                entity.Property(e => e.ClassifyId)
                    .HasColumnType("int(12)")
                    .HasColumnName("classify_id")
                    .HasComment("音乐分类ID");

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(255)
                    .HasColumnName("file_url")
                    .HasDefaultValueSql("''")
                    .HasComment("文件地址");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .HasColumnName("img_url")
                    .HasDefaultValueSql("''")
                    .HasComment("封面地址");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("是否被删除 0否 1是");

                entity.Property(e => e.Length)
                    .HasMaxLength(255)
                    .HasColumnName("length")
                    .HasDefaultValueSql("''")
                    .HasComment("音乐长度");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("音乐名称");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasComment("更新时间");

                entity.Property(e => e.UploadType)
                    .HasColumnName("upload_type")
                    .HasComment("上传类型  1管理员上传 2 用户上传");

                entity.Property(e => e.Uploader)
                    .HasColumnType("int(255)")
                    .HasColumnName("uploader")
                    .HasComment("上传者ID");

                entity.Property(e => e.UseNums)
                    .HasColumnType("int(12)")
                    .HasColumnName("use_nums")
                    .HasComment("被使用次数");
            });

            modelBuilder.Entity<CmfMusicClassify>(entity =>
            {
                entity.ToTable("cmf_music_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .HasColumnName("img_url")
                    .HasDefaultValueSql("''")
                    .HasComment("分类图标地址");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("是否删除");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(12)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("排序号");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名称");

                entity.Property(e => e.TitleEn)
                    .HasMaxLength(255)
                    .HasColumnName("title_en");

                entity.Property(e => e.TitleNam)
                    .HasMaxLength(255)
                    .HasColumnName("title_nam");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<CmfMusicCollection>(entity =>
            {
                entity.ToTable("cmf_music_collection");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.MusicId)
                    .HasColumnType("int(12)")
                    .HasColumnName("music_id")
                    .HasComment("音乐id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("音乐收藏状态 1收藏 0 取消收藏");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户id");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfNav>(entity =>
            {
                entity.ToTable("cmf_nav");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cid)
                    .HasColumnType("int(11)")
                    .HasColumnName("cid")
                    .HasComment("导航分类 id");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasComment("导航链接");

                entity.Property(e => e.Icon)
                    .HasMaxLength(255)
                    .HasColumnName("icon")
                    .HasComment("导航图标");

                entity.Property(e => e.Label)
                    .HasMaxLength(255)
                    .HasColumnName("label")
                    .HasComment("导航标题");

                entity.Property(e => e.Listorder)
                    .HasColumnType("int(6)")
                    .HasColumnName("listorder")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序");

                entity.Property(e => e.Parentid)
                    .HasColumnType("int(11)")
                    .HasColumnName("parentid")
                    .HasComment("导航父 id");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("'0'")
                    .HasComment("层级关系");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1显示，0不显示");

                entity.Property(e => e.Target)
                    .HasMaxLength(50)
                    .HasColumnName("target")
                    .HasComment("打开方式");
            });

            modelBuilder.Entity<CmfNavCat>(entity =>
            {
                entity.HasKey(e => e.Navcid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_nav_cat");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Navcid)
                    .HasColumnType("int(11)")
                    .HasColumnName("navcid");

                entity.Property(e => e.Active)
                    .HasColumnType("int(1)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否为主菜单，1是，0不是");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("导航分类名");

                entity.Property(e => e.Remark)
                    .HasColumnType("text")
                    .HasColumnName("remark")
                    .HasComment("备注");
            });

            modelBuilder.Entity<CmfNavMenu>(entity =>
            {
                entity.ToTable("cmf_nav_menu");

                entity.HasComment("前台导航菜单表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Href)
                    .HasMaxLength(100)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("链接");

                entity.Property(e => e.Icon)
                    .HasMaxLength(20)
                    .HasColumnName("icon")
                    .HasDefaultValueSql("''")
                    .HasComment("图标");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("菜单名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NavId)
                    .HasColumnType("int(11)")
                    .HasColumnName("nav_id")
                    .HasComment("导航 id");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_id")
                    .HasComment("父 id");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''")
                    .HasComment("层级关系");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:显示;0:隐藏");

                entity.Property(e => e.Target)
                    .HasMaxLength(10)
                    .HasColumnName("target")
                    .HasDefaultValueSql("''")
                    .HasComment("打开方式");
            });

            modelBuilder.Entity<CmfOauthUser>(entity =>
            {
                entity.ToTable("cmf_oauth_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(512)
                    .HasColumnName("access_token");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("绑定时间");

                entity.Property(e => e.ExpiresDate)
                    .HasColumnType("int(11)")
                    .HasColumnName("expires_date")
                    .HasComment("access_token过期时间");

                entity.Property(e => e.From)
                    .HasMaxLength(20)
                    .HasColumnName("from")
                    .HasComment("用户来源key");

                entity.Property(e => e.HeadImg)
                    .HasMaxLength(200)
                    .HasColumnName("head_img")
                    .HasComment("头像");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(16)
                    .HasColumnName("last_login_ip")
                    .HasComment("最后登录ip");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_time")
                    .HasComment("最后登录时间");

                entity.Property(e => e.LoginTimes)
                    .HasColumnType("int(6)")
                    .HasColumnName("login_times")
                    .HasComment("登录次数");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .HasComment("第三方昵称");

                entity.Property(e => e.Openid)
                    .HasMaxLength(40)
                    .HasColumnName("openid")
                    .HasComment("第三方用户id");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("status");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20)")
                    .HasColumnName("uid")
                    .HasComment("关联的本站用户id");
            });

            modelBuilder.Entity<CmfOption>(entity =>
            {
                entity.ToTable("cmf_option");

                entity.HasComment("全站配置表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.OptionName, "option_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Autoload)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("autoload")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否自动加载;1:自动加载;0:不自动加载");

                entity.Property(e => e.OptionName)
                    .HasMaxLength(64)
                    .HasColumnName("option_name")
                    .HasDefaultValueSql("''")
                    .HasComment("配置名");

                entity.Property(e => e.OptionValue)
                    .HasColumnName("option_value")
                    .HasComment("配置值")
                    .UseCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<CmfOption1>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_options");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.OptionName, "option_name")
                    .IsUnique();

                entity.Property(e => e.OptionId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("option_id");

                entity.Property(e => e.Autoload)
                    .HasColumnType("int(2)")
                    .HasColumnName("autoload")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否自动加载");

                entity.Property(e => e.OptionName)
                    .HasMaxLength(64)
                    .HasColumnName("option_name")
                    .HasComment("配置名");

                entity.Property(e => e.OptionValue)
                    .HasColumnName("option_value")
                    .HasComment("配置值");
            });

            modelBuilder.Entity<CmfPageSetting>(entity =>
            {
                entity.ToTable("cmf_page_setting");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .HasColumnName("desc");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.IsOpen)
                    .HasColumnType("int(11)")
                    .HasColumnName("is_open");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasColumnName("sort");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("update_time");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<CmfPaidprogram>(entity =>
            {
                entity.ToTable("cmf_paidprogram");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Id, e.Uid }, "id_uid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Classid)
                    .HasColumnType("int(11)")
                    .HasColumnName("classid")
                    .HasComment("分类ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("内容简介");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.EvaluateNums)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("evaluate_nums")
                    .HasComment("评价总人数");

                entity.Property(e => e.EvaluateTotal)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("evaluate_total")
                    .HasComment("评价总分");

                entity.Property(e => e.Money)
                    .HasPrecision(11, 2)
                    .HasColumnName("money")
                    .HasComment("付费内容价格");

                entity.Property(e => e.PersonalDesc)
                    .HasMaxLength(255)
                    .HasColumnName("personal_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("个人介绍");

                entity.Property(e => e.SaleNums)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sale_nums")
                    .HasComment("购买数量");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("是否审核通过 -1 拒绝 0 审核中 1 通过");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("文件类型 0 单视频 1 多视频");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videos)
                    .HasColumnType("text")
                    .HasColumnName("videos")
                    .HasComment("视频json串");
            });

            modelBuilder.Entity<CmfPaidprogramApply>(entity =>
            {
                entity.ToTable("cmf_paidprogram_apply");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Percent)
                    .HasColumnType("int(11)")
                    .HasColumnName("percent")
                    .HasComment("抽水比例");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("审核状态 -1 拒绝 0 审核中 1 通过");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<CmfPaidprogramClass>(entity =>
            {
                entity.ToTable("cmf_paidprogram_class");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasComment("排序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态 0不显示 1 显示");
            });

            modelBuilder.Entity<CmfPaidprogramComment>(entity =>
            {
                entity.ToTable("cmf_paidprogram_comment");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("发布时间");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasComment("评价等级");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("object_id")
                    .HasComment("付费项目ID");

                entity.Property(e => e.Touid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("touid")
                    .HasComment("项目发布者ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfPaidprogramOrder>(entity =>
            {
                entity.ToTable("cmf_paidprogram_order");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.ObjectId, e.Status }, "uid_objectid_status");

                entity.HasIndex(e => new { e.Uid, e.Status }, "uid_status");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("下单时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("是否删除 0 否 1 是（用于删除付费项目）");

                entity.Property(e => e.Money)
                    .HasPrecision(20, 2)
                    .HasColumnName("money")
                    .HasComment("金额");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("object_id")
                    .HasComment("付费项目ID");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(255)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("订单编号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("订单状态 0 未支付 1 已支付");

                entity.Property(e => e.Touid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("touid")
                    .HasComment("付费项目发布者ID");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(255)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方订单编号");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("支付方式 1 支付宝 2 微信 3 余额");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfPayMethod>(entity =>
            {
                entity.ToTable("cmf_pay_method");

                entity.HasComment("支付管理")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("主键");

                entity.Property(e => e.Createtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("createtime")
                    .HasComment("创建时间");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("提交地址");

                entity.Property(e => e.IsOpen)
                    .HasColumnName("is_open")
                    .HasComment("是否外部浏览器打开 1:是; 0:否");

                entity.Property(e => e.IsSwitch)
                    .HasColumnName("is_switch")
                    .HasComment("是否开启 1:未开启; 0:未开启");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("支付名称");

                entity.Property(e => e.Sort)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'50'")
                    .HasComment("排序");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型 1:支付宝; 2:微信;");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(11)")
                    .HasColumnName("updatetime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfPhonePrefix>(entity =>
            {
                entity.ToTable("cmf_phone_prefix");

                entity.HasComment("国际电话号码区号")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("area")
                    .HasComment("所在的洲");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country")
                    .HasComment("国家名称");

                entity.Property(e => e.Prefix)
                    .HasColumnType("int(10)")
                    .HasColumnName("prefix")
                    .HasComment("区号");
            });

            modelBuilder.Entity<CmfPlugin>(entity =>
            {
                entity.ToTable("cmf_plugin");

                entity.HasComment("插件表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Author)
                    .HasMaxLength(20)
                    .HasColumnName("author")
                    .HasDefaultValueSql("''")
                    .HasComment("插件作者")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AuthorUrl)
                    .HasMaxLength(50)
                    .HasColumnName("author_url")
                    .HasDefaultValueSql("''")
                    .HasComment("作者网站链接");

                entity.Property(e => e.Config)
                    .HasColumnType("text")
                    .HasColumnName("config")
                    .HasComment("插件配置");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("插件安装时间");

                entity.Property(e => e.DemoUrl)
                    .HasMaxLength(50)
                    .HasColumnName("demo_url")
                    .HasDefaultValueSql("''")
                    .HasComment("演示地址，带协议");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasComment("插件描述");

                entity.Property(e => e.HasAdmin)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("has_admin")
                    .HasComment("是否有后台管理,0:没有;1:有");

                entity.Property(e => e.Hooks)
                    .HasMaxLength(255)
                    .HasColumnName("hooks")
                    .HasDefaultValueSql("''")
                    .HasComment("实现的钩子;以“,”分隔");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("插件标识名,英文字母(惟一)");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:开启;0:禁用");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("插件名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("插件类型;1:网站;8:微信");

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''")
                    .HasComment("插件版本号");
            });

            modelBuilder.Entity<CmfPlugin1>(entity =>
            {
                entity.ToTable("cmf_plugins");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .HasColumnName("author")
                    .HasDefaultValueSql("''")
                    .HasComment("插件作者");

                entity.Property(e => e.Config)
                    .HasColumnType("text")
                    .HasColumnName("config")
                    .HasComment("插件配置");

                entity.Property(e => e.Createtime)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("createtime")
                    .HasComment("插件安装时间");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("插件描述");

                entity.Property(e => e.HasAdmin)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("has_admin")
                    .HasDefaultValueSql("'0'")
                    .HasComment("插件是否有后台管理界面");

                entity.Property(e => e.Hooks)
                    .HasMaxLength(255)
                    .HasColumnName("hooks")
                    .HasComment("实现的钩子;以“，”分隔");

                entity.Property(e => e.Listorder)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("listorder")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("插件名，英文");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态；1开启；");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("插件名称");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'")
                    .HasComment("插件类型, 1:网站；8;微信");

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''")
                    .HasComment("插件版本号");
            });

            modelBuilder.Entity<CmfPortalCategory>(entity =>
            {
                entity.ToTable("cmf_portal_category");

                entity.HasComment("portal应用 文章分类表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id")
                    .HasComment("分类id");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("delete_time")
                    .HasComment("删除时间");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("分类描述");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.ListTpl)
                    .HasMaxLength(50)
                    .HasColumnName("list_tpl")
                    .HasDefaultValueSql("''")
                    .HasComment("分类列表模板");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展属性");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.OneTpl)
                    .HasMaxLength(50)
                    .HasColumnName("one_tpl")
                    .HasDefaultValueSql("''")
                    .HasComment("分类文章页模板");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id")
                    .HasComment("分类父id");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''")
                    .HasComment("分类层级关系路径");

                entity.Property(e => e.PostCount)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_count")
                    .HasComment("分类文章数");

                entity.Property(e => e.SeoDescription)
                    .HasMaxLength(255)
                    .HasColumnName("seo_description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoKeywords)
                    .HasMaxLength(255)
                    .HasColumnName("seo_keywords")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoTitle)
                    .HasMaxLength(100)
                    .HasColumnName("seo_title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:发布,0:不发布");
            });

            modelBuilder.Entity<CmfPortalCategoryPost>(entity =>
            {
                entity.ToTable("cmf_portal_category_post");

                entity.HasComment("portal应用 分类文章对应表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CategoryId, "term_taxonomy_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("category_id")
                    .HasComment("分类id");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.PostId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_id")
                    .HasComment("文章id");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:发布;0:不发布");
            });

            modelBuilder.Entity<CmfPortalPost>(entity =>
            {
                entity.ToTable("cmf_portal_post");

                entity.HasComment("portal应用 文章表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.CreateTime, "create_time");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => new { e.PostType, e.PostStatus, e.CreateTime, e.Id }, "type_status_date");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CommentCount)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("comment_count")
                    .HasComment("评论数");

                entity.Property(e => e.CommentStatus)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("comment_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("评论状态;1:允许;0:不允许");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("delete_time")
                    .HasComment("删除时间");

                entity.Property(e => e.IsTop)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("is_top")
                    .HasComment("是否置顶;1:置顶;0:不置顶");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展属性,如缩略图;格式为json");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id")
                    .HasComment("父级id");

                entity.Property(e => e.PostContent)
                    .HasColumnType("text")
                    .HasColumnName("post_content")
                    .HasComment("文章内容");

                entity.Property(e => e.PostContentEn)
                    .HasColumnType("text")
                    .HasColumnName("post_content_en");

                entity.Property(e => e.PostContentFiltered)
                    .HasColumnType("text")
                    .HasColumnName("post_content_filtered")
                    .HasComment("处理过的文章内容");

                entity.Property(e => e.PostContentNam)
                    .HasColumnType("text")
                    .HasColumnName("post_content_nam");

                entity.Property(e => e.PostExcerpt)
                    .HasMaxLength(500)
                    .HasColumnName("post_excerpt")
                    .HasDefaultValueSql("''")
                    .HasComment("post摘要");

                entity.Property(e => e.PostFavorites)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("post_favorites")
                    .HasComment("收藏数");

                entity.Property(e => e.PostFormat)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("post_format")
                    .HasDefaultValueSql("'1'")
                    .HasComment("内容格式;1:html;2:md");

                entity.Property(e => e.PostHits)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_hits")
                    .HasComment("查看数");

                entity.Property(e => e.PostKeywords)
                    .HasMaxLength(150)
                    .HasColumnName("post_keywords")
                    .HasDefaultValueSql("''")
                    .HasComment("seo keywords");

                entity.Property(e => e.PostLike)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_like")
                    .HasComment("点赞数");

                entity.Property(e => e.PostSource)
                    .HasMaxLength(150)
                    .HasColumnName("post_source")
                    .HasDefaultValueSql("''")
                    .HasComment("转载文章的来源");

                entity.Property(e => e.PostStatus)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("post_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:已发布;0:未发布;");

                entity.Property(e => e.PostTitle)
                    .HasMaxLength(100)
                    .HasColumnName("post_title")
                    .HasDefaultValueSql("''")
                    .HasComment("post标题")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PostTitleEn)
                    .HasMaxLength(255)
                    .HasColumnName("post_title_en")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostTitleNam)
                    .HasMaxLength(255)
                    .HasColumnName("post_title_nam")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostType)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("post_type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("类型,1:文章;2:页面");

                entity.Property(e => e.PublishedTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("published_time")
                    .HasComment("发布时间");

                entity.Property(e => e.Recommended)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("recommended")
                    .HasComment("是否推荐;1:推荐;0:不推荐");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(100)
                    .HasColumnName("thumbnail")
                    .HasDefaultValueSql("''")
                    .HasComment("缩略图");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("页面类型，0单页面，2关于我们");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("update_time")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("发表者用户id");
            });

            modelBuilder.Entity<CmfPortalTag>(entity =>
            {
                entity.ToTable("cmf_portal_tag");

                entity.HasComment("portal应用 文章标签表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id")
                    .HasComment("分类id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("标签名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PostCount)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_count")
                    .HasComment("标签文章数");

                entity.Property(e => e.Recommended)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("recommended")
                    .HasComment("是否推荐;1:推荐;0:不推荐");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:发布,0:不发布");
            });

            modelBuilder.Entity<CmfPortalTagPost>(entity =>
            {
                entity.ToTable("cmf_portal_tag_post");

                entity.HasComment("portal应用 标签文章对应表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PostId, "post_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.PostId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_id")
                    .HasComment("文章 id");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:发布;0:不发布");

                entity.Property(e => e.TagId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("tag_id")
                    .HasComment("标签 id");
            });

            modelBuilder.Entity<CmfPost>(entity =>
            {
                entity.ToTable("cmf_posts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.PostAuthor, "post_author");

                entity.HasIndex(e => e.PostDate, "post_date");

                entity.HasIndex(e => e.PostParent, "post_parent");

                entity.HasIndex(e => new { e.PostType, e.PostStatus, e.PostDate, e.Id }, "type_status_date");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CommentCount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("comment_count")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CommentStatus)
                    .HasColumnType("int(2)")
                    .HasColumnName("comment_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("评论状态，1允许，0不允许");

                entity.Property(e => e.Istop)
                    .HasColumnName("istop")
                    .HasDefaultValueSql("'0'")
                    .HasComment("置顶 1置顶； 0不置顶");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(10)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PostAuthor)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_author")
                    .HasDefaultValueSql("'0'")
                    .HasComment("发表者id");

                entity.Property(e => e.PostContent)
                    .HasColumnName("post_content")
                    .HasComment("post内容");

                entity.Property(e => e.PostContentFiltered).HasColumnName("post_content_filtered");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("'2000-01-01 00:00:00'")
                    .HasComment("post创建日期，永久不变，一般不显示给用户");

                entity.Property(e => e.PostExcerpt)
                    .HasColumnType("text")
                    .HasColumnName("post_excerpt")
                    .HasComment("post摘要");

                entity.Property(e => e.PostHits)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_hits")
                    .HasDefaultValueSql("'0'")
                    .HasComment("post点击数，查看数");

                entity.Property(e => e.PostKeywords)
                    .HasMaxLength(150)
                    .HasColumnName("post_keywords")
                    .HasDefaultValueSql("''")
                    .HasComment("seo keywords");

                entity.Property(e => e.PostLike)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_like")
                    .HasDefaultValueSql("'0'")
                    .HasComment("post赞数");

                entity.Property(e => e.PostMimeType)
                    .HasMaxLength(100)
                    .HasColumnName("post_mime_type")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostModified)
                    .HasColumnType("datetime")
                    .HasColumnName("post_modified")
                    .HasDefaultValueSql("'2000-01-01 00:00:00'")
                    .HasComment("post更新时间，可在前台修改，显示给用户");

                entity.Property(e => e.PostParent)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_parent")
                    .HasDefaultValueSql("'0'")
                    .HasComment("post的父级post id,表示post层级关系");

                entity.Property(e => e.PostSource)
                    .HasMaxLength(150)
                    .HasColumnName("post_source")
                    .HasComment("转载文章的来源");

                entity.Property(e => e.PostStatus)
                    .HasColumnType("int(2)")
                    .HasColumnName("post_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("post状态，1已审核，0未审核");

                entity.Property(e => e.PostTitle)
                    .HasColumnType("text")
                    .HasColumnName("post_title")
                    .HasComment("post标题");

                entity.Property(e => e.PostType)
                    .HasColumnType("int(2)")
                    .HasColumnName("post_type");

                entity.Property(e => e.Recommended)
                    .HasColumnName("recommended")
                    .HasDefaultValueSql("'0'")
                    .HasComment("推荐 1推荐 0不推荐");

                entity.Property(e => e.Smeta)
                    .HasColumnType("text")
                    .HasColumnName("smeta")
                    .HasComment("post的扩展字段，保存相关扩展属性，如缩略图；格式为json");

                entity.Property(e => e.Type)
                    .HasColumnType("int(3)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfPushrecord>(entity =>
            {
                entity.ToTable("cmf_pushrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("发送时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("''")
                    .HasComment("管理员账号");

                entity.Property(e => e.Adminid)
                    .HasColumnType("int(11)")
                    .HasColumnName("adminid")
                    .HasComment("管理员ID");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("推送内容");

                entity.Property(e => e.Ip)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ip")
                    .HasComment("管理员IP地址");

                entity.Property(e => e.Touid)
                    .HasColumnType("text")
                    .HasColumnName("touid")
                    .HasComment("推送对象");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("消息类型 0 后台手动发布的系统消息 1 商品消息");
            });

            modelBuilder.Entity<CmfReceive>(entity =>
            {
                entity.ToTable("cmf_receive");

                entity.HasComment("领取任务表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasComment("发布时间");

                entity.Property(e => e.Link)
                    .HasColumnType("text")
                    .HasColumnName("link")
                    .HasComment("分享的连接");

                entity.Property(e => e.ReceiveTime)
                    .HasColumnType("datetime")
                    .HasColumnName("receive_time")
                    .HasComment("领取时间");

                entity.Property(e => e.TaskId)
                    .HasColumnType("int(11)")
                    .HasColumnName("task_id")
                    .HasComment("任务ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id")
                    .HasComment("领取人ID");
            });

            modelBuilder.Entity<CmfRecord>(entity =>
            {
                entity.ToTable("cmf_record");

                entity.HasComment("注册记录表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("endtime")
                    .HasComment("完成时间");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1、未完成 2、已完成");

                entity.Property(e => e.TaskId)
                    .HasColumnType("int(11)")
                    .HasColumnName("task_id")
                    .HasComment("任务ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("领取人ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfRecycleBin>(entity =>
            {
                entity.ToTable("cmf_recycle_bin");

                entity.HasComment(" 回收站")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("'0'")
                    .HasComment("创建时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("删除内容名称");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("object_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("删除内容 id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(60)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''")
                    .HasComment("删除内容所在表名");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfRed>(entity =>
            {
                entity.ToTable("cmf_red");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Showid, e.Liveuid }, "liveuid_showid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.CoinRob)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_rob")
                    .HasComment("钻石数");

                entity.Property(e => e.Des)
                    .HasMaxLength(255)
                    .HasColumnName("des")
                    .HasDefaultValueSql("''")
                    .HasComment("描述");

                entity.Property(e => e.Effecttime)
                    .HasColumnType("int(11)")
                    .HasColumnName("effecttime")
                    .HasComment("生效时间");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.NumsRob)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums_rob")
                    .HasComment("数量");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(11)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("状态，0抢中，1抢完");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("红包类型，0平均，1手气");

                entity.Property(e => e.TypeGrant)
                    .HasColumnName("type_grant")
                    .HasComment("发放类型，0立即，1延迟");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfRedRecord>(entity =>
            {
                entity.ToTable("cmf_red_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Redid, "redid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("金额");

                entity.Property(e => e.Redid)
                    .HasColumnType("int(11)")
                    .HasColumnName("redid")
                    .HasComment("红包ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfReport>(entity =>
            {
                entity.ToTable("cmf_report");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("内容");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfReportClassify>(entity =>
            {
                entity.ToTable("cmf_report_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(10)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("举报类型名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");
            });

            modelBuilder.Entity<CmfRole>(entity =>
            {
                entity.ToTable("cmf_role");

                entity.HasComment("角色表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => e.Status, "status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("角色名称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("parent_id")
                    .HasComment("父角色ID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("''")
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasComment("状态;0:禁用;1:正常");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("update_time")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfRoleUser>(entity =>
            {
                entity.ToTable("cmf_role_user");

                entity.HasComment("用户角色对应表")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("role_id")
                    .HasComment("角色 id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfRoute>(entity =>
            {
                entity.ToTable("cmf_route");

                entity.HasComment("url路由表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("路由id");

                entity.Property(e => e.FullUrl)
                    .HasMaxLength(255)
                    .HasColumnName("full_url")
                    .HasDefaultValueSql("''")
                    .HasComment("完整url");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:启用,0:不启用");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("URL规则类型;1:用户自定义;2:别名添加");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''")
                    .HasComment("实际显示的url");
            });

            modelBuilder.Entity<CmfSellerGoodsClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_seller_goods_class");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.GoodsClassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("goods_classid")
                    .HasComment("商品一级分类id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("是否显示 0 否 1 是");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfSendcode>(entity =>
            {
                entity.ToTable("cmf_sendcode");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasComment("接收账号");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("消息内容");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("消息类型，1表示短信验证码，2表示邮箱验证码");
            });

            modelBuilder.Entity<CmfSettlementCharge>(entity =>
            {
                entity.ToTable("cmf_settlement_charge");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("int(11)")
                    .HasColumnName("date")
                    .HasComment("日期");

                entity.Property(e => e.Money)
                    .HasPrecision(20, 2)
                    .HasColumnName("money")
                    .HasComment("当天充值金额");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0未结算，1已结算");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfSettlementChargeRecord>(entity =>
            {
                entity.ToTable("cmf_settlement_charge_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Date)
                    .HasColumnType("int(11)")
                    .HasColumnName("date")
                    .HasComment("结算日期");

                entity.Property(e => e.Money)
                    .HasPrecision(20, 2)
                    .HasColumnName("money")
                    .HasComment("结算金额");

                entity.Property(e => e.TimeSlot)
                    .HasMaxLength(255)
                    .HasColumnName("time_slot")
                    .HasDefaultValueSql("''")
                    .HasComment("结算时间段");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfSettlementVote>(entity =>
            {
                entity.ToTable("cmf_settlement_votes");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("int(11)")
                    .HasColumnName("date")
                    .HasComment("日期");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0未结算，1已结算");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Votes)
                    .HasPrecision(20, 2)
                    .HasColumnName("votes")
                    .HasComment("当天总映票");
            });

            modelBuilder.Entity<CmfSettlementVotesRecord>(entity =>
            {
                entity.ToTable("cmf_settlement_votes_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Date)
                    .HasColumnType("int(11)")
                    .HasColumnName("date")
                    .HasComment("结算日期");

                entity.Property(e => e.TimeSlot)
                    .HasMaxLength(255)
                    .HasColumnName("time_slot")
                    .HasDefaultValueSql("''")
                    .HasComment("结算时间段");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Votes)
                    .HasPrecision(20, 2)
                    .HasColumnName("votes")
                    .HasComment("结算映票");
            });

            modelBuilder.Entity<CmfShopAddress>(entity =>
            {
                entity.ToTable("cmf_shop_address");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''")
                    .HasComment("详细地址");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("area")
                    .HasDefaultValueSql("''")
                    .HasComment("区");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("市");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country")
                    .HasDefaultValueSql("''")
                    .HasComment("国家");

                entity.Property(e => e.CountryCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_code")
                    .HasDefaultValueSql("'86'")
                    .HasComment("国家代号");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasComment("是否为默认地址 0 否 1 是");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''")
                    .HasComment("电话");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.ReceiverCountry)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_country")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfShopApply>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_shop_apply");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''")
                    .HasComment("详细地址");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("area")
                    .HasDefaultValueSql("''")
                    .HasComment("地区");

                entity.Property(e => e.Cardno)
                    .HasMaxLength(255)
                    .HasColumnName("cardno")
                    .HasDefaultValueSql("''")
                    .HasComment("身份证号码");

                entity.Property(e => e.Certificate)
                    .HasMaxLength(255)
                    .HasColumnName("certificate")
                    .HasDefaultValueSql("''")
                    .HasComment("营业执照");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("市");

                entity.Property(e => e.Contact)
                    .HasMaxLength(255)
                    .HasColumnName("contact")
                    .HasDefaultValueSql("''")
                    .HasComment("联系人");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_code")
                    .HasDefaultValueSql("'86'")
                    .HasComment("国家代号");

                entity.Property(e => e.Des)
                    .HasMaxLength(255)
                    .HasColumnName("des")
                    .HasDefaultValueSql("''")
                    .HasComment("简介");

                entity.Property(e => e.ExpressPoints)
                    .HasColumnType("float(11,1)")
                    .HasColumnName("express_points")
                    .HasComment("物流服务平均分");

                entity.Property(e => e.License)
                    .HasMaxLength(255)
                    .HasColumnName("license")
                    .HasDefaultValueSql("''")
                    .HasComment("许可证");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.OrderPercent)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_percent")
                    .HasComment("订单分成比例");

                entity.Property(e => e.Other)
                    .HasMaxLength(255)
                    .HasColumnName("other")
                    .HasComment("其他证件");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''")
                    .HasComment("电话");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.QualityPoints)
                    .HasColumnType("float(11,1)")
                    .HasColumnName("quality_points")
                    .HasComment("店铺商品质量(商品描述)平均分");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason")
                    .HasDefaultValueSql("''")
                    .HasComment("原因");

                entity.Property(e => e.Receiver)
                    .HasMaxLength(255)
                    .HasColumnName("receiver")
                    .HasDefaultValueSql("''")
                    .HasComment("退货收货人");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_address")
                    .HasComment("退货人详细地址");

                entity.Property(e => e.ReceiverArea)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_area")
                    .HasComment("退货人地区");

                entity.Property(e => e.ReceiverCity)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_city")
                    .HasDefaultValueSql("''")
                    .HasComment("退货人市");

                entity.Property(e => e.ReceiverCountry)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_country")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ReceiverPhone)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_phone")
                    .HasDefaultValueSql("''")
                    .HasComment("退货人联系电话");

                entity.Property(e => e.ReceiverProvince)
                    .HasMaxLength(255)
                    .HasColumnName("receiver_province")
                    .HasDefaultValueSql("''")
                    .HasComment("退货人省份");

                entity.Property(e => e.SaleNums)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("sale_nums")
                    .HasComment("店铺总销量");

                entity.Property(e => e.ServicePhone)
                    .HasMaxLength(255)
                    .HasColumnName("service_phone")
                    .HasDefaultValueSql("''")
                    .HasComment("客服电话");

                entity.Property(e => e.ServicePoints)
                    .HasColumnType("float(11,1)")
                    .HasColumnName("service_points")
                    .HasComment("店铺服务态度平均分");

                entity.Property(e => e.ShipmentOverdueNum)
                    .HasColumnType("int(11)")
                    .HasColumnName("shipment_overdue_num")
                    .HasComment("店铺逾期发货次数");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0审核中1通过2拒绝");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''")
                    .HasComment("联系人姓名");
            });

            modelBuilder.Entity<CmfShopBond>(entity =>
            {
                entity.ToTable("cmf_shop_bond");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addtime")
                    .HasComment("支付时间");

                entity.Property(e => e.Bond)
                    .HasColumnType("int(11)")
                    .HasColumnName("bond")
                    .HasComment("保证金");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("状态，0已退回1已支付,-1已扣除");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfShopExpress>(entity =>
            {
                entity.ToTable("cmf_shop_express");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("自增ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("编辑时间");

                entity.Property(e => e.ExpressCode)
                    .HasMaxLength(255)
                    .HasColumnName("express_code")
                    .HasDefaultValueSql("''")
                    .HasComment("快递公司对应三方平台的编码");

                entity.Property(e => e.ExpressName)
                    .HasMaxLength(255)
                    .HasColumnName("express_name")
                    .HasDefaultValueSql("''")
                    .HasComment("快递公司电话");

                entity.Property(e => e.ExpressPhone)
                    .HasMaxLength(255)
                    .HasColumnName("express_phone")
                    .HasDefaultValueSql("''")
                    .HasComment("快递公司客服电话");

                entity.Property(e => e.ExpressStatus)
                    .IsRequired()
                    .HasColumnName("express_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否显示 0 否 1 是");

                entity.Property(e => e.ExpressThumb)
                    .HasMaxLength(255)
                    .HasColumnName("express_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("快递公司图标");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasComment("排序号");
            });

            modelBuilder.Entity<CmfShopGood>(entity =>
            {
                entity.ToTable("cmf_shop_goods");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Status }, "uid_status");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasComment("商品文字内容");

                entity.Property(e => e.GoodsDesc)
                    .HasMaxLength(255)
                    .HasColumnName("goods_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("站外商品简介");

                entity.Property(e => e.Hits)
                    .HasColumnType("int(11)")
                    .HasColumnName("hits")
                    .HasComment("点击数");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("站外商品链接");

                entity.Property(e => e.Isrecom)
                    .HasColumnName("isrecom")
                    .HasComment("推荐，0否1是");

                entity.Property(e => e.Issale)
                    .HasColumnName("issale")
                    .HasComment("商品是否在直播间销售 0 否 1 是");

                entity.Property(e => e.LiveIsshow)
                    .HasColumnName("live_isshow")
                    .HasComment("直播间是否展示商品简介 0 否 1 是 默认0");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.OneClassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("one_classid")
                    .HasComment("商品一级分类");

                entity.Property(e => e.OriginalPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("original_price")
                    .HasComment("站外商品原价");

                entity.Property(e => e.Pictures)
                    .HasColumnType("text")
                    .HasColumnName("pictures")
                    .HasComment("商品内容图集");

                entity.Property(e => e.Postage)
                    .HasColumnType("int(11)")
                    .HasColumnName("postage")
                    .HasComment("邮费");

                entity.Property(e => e.PresentPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("present_price")
                    .HasComment("站外商品现价");

                entity.Property(e => e.RefuseReason)
                    .HasMaxLength(255)
                    .HasColumnName("refuse_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("商品拒绝原因");

                entity.Property(e => e.SaleNums)
                    .HasColumnType("int(11)")
                    .HasColumnName("sale_nums")
                    .HasComment("总销量");

                entity.Property(e => e.Specs)
                    .HasColumnName("specs")
                    .HasComment("商品规格");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0审核中-1商家下架1通过-2管理员下架 2拒绝");

                entity.Property(e => e.ThreeClassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("three_classid")
                    .HasComment("商品三级分类");

                entity.Property(e => e.Thumbs)
                    .HasColumnType("text")
                    .HasColumnName("thumbs")
                    .HasComment("封面");

                entity.Property(e => e.TwoClassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("two_classid")
                    .HasComment("商品二级分类");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("商品类型 0 站内商品 1 站外商品");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.VideoThumb)
                    .HasMaxLength(255)
                    .HasColumnName("video_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("商品视频封面");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(255)
                    .HasColumnName("video_url")
                    .HasDefaultValueSql("''")
                    .HasComment("商品视频地址");
            });

            modelBuilder.Entity<CmfShopGoodsClass>(entity =>
            {
                entity.HasKey(e => e.GcId)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_shop_goods_class");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.GcGrade, "gc_grade");

                entity.HasIndex(e => e.GcParentid, "gc_parentid");

                entity.HasIndex(e => new { e.GcParentid, e.GcIsshow }, "list1");

                entity.HasIndex(e => new { e.GcOneId, e.GcGrade }, "list2");

                entity.Property(e => e.GcId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("gc_id")
                    .HasComment("商品分类ID");

                entity.Property(e => e.GcAddtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("gc_addtime")
                    .HasComment("商品分类添加时间");

                entity.Property(e => e.GcEdittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("gc_edittime")
                    .HasComment("商品分类修改时间");

                entity.Property(e => e.GcGrade)
                    .HasColumnName("gc_grade")
                    .HasComment("商品分类等级");

                entity.Property(e => e.GcIsshow)
                    .HasColumnName("gc_isshow")
                    .HasComment("是否展示 0 否 1 是");

                entity.Property(e => e.GcName)
                    .HasMaxLength(255)
                    .HasColumnName("gc_name")
                    .HasDefaultValueSql("''")
                    .HasComment("商品分类名称");

                entity.Property(e => e.GcNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("gc_name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.GcNameNam)
                    .HasMaxLength(255)
                    .HasColumnName("gc_name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.GcOneId)
                    .HasColumnType("int(11)")
                    .HasColumnName("gc_one_id")
                    .HasComment("所属一级分类ID");

                entity.Property(e => e.GcParentid)
                    .HasColumnType("int(11)")
                    .HasColumnName("gc_parentid")
                    .HasComment("上级分类ID");

                entity.Property(e => e.GcSort)
                    .HasColumnType("int(11)")
                    .HasColumnName("gc_sort")
                    .HasComment("商品分类排序号");
            });

            modelBuilder.Entity<CmfShopOrder>(entity =>
            {
                entity.ToTable("cmf_shop_order");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Id, e.ShopUid }, "id_shopuid");

                entity.HasIndex(e => new { e.Id, e.Uid }, "id_uid");

                entity.HasIndex(e => new { e.ShopUid, e.Status }, "shopuid_status");

                entity.HasIndex(e => new { e.ShopUid, e.Status, e.RefundStatus }, "shopuid_status_refundstatus");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id")
                    .HasComment("订单ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者详细地址");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("订单添加时间");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("area")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者地区");

                entity.Property(e => e.CancelTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("cancel_time")
                    .HasComment("订单取消时间");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者市");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country")
                    .HasDefaultValueSql("''")
                    .HasComment("国家");

                entity.Property(e => e.CountryCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_code")
                    .HasComment("国家代号");

                entity.Property(e => e.EvaluateTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaluate_time")
                    .HasComment("订单评价时间");

                entity.Property(e => e.ExpressCode)
                    .HasMaxLength(255)
                    .HasColumnName("express_code")
                    .HasDefaultValueSql("''")
                    .HasComment("快递公司对应三方平台的编码");

                entity.Property(e => e.ExpressName)
                    .HasMaxLength(255)
                    .HasColumnName("express_name")
                    .HasDefaultValueSql("''")
                    .HasComment("物流公司名称");

                entity.Property(e => e.ExpressNumber)
                    .HasMaxLength(255)
                    .HasColumnName("express_number")
                    .HasDefaultValueSql("''")
                    .HasComment("物流单号");

                entity.Property(e => e.ExpressPhone)
                    .HasMaxLength(255)
                    .HasColumnName("express_phone")
                    .HasDefaultValueSql("''")
                    .HasComment("物流公司电话");

                entity.Property(e => e.ExpressThumb)
                    .HasMaxLength(255)
                    .HasColumnName("express_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("物流公司图标");

                entity.Property(e => e.GoodsName)
                    .HasMaxLength(255)
                    .HasColumnName("goods_name")
                    .HasDefaultValueSql("''")
                    .HasComment("商品名称");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goodsid")
                    .HasComment("商品id");

                entity.Property(e => e.IsAppendEvaluate)
                    .IsRequired()
                    .HasColumnName("is_append_evaluate")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否可追加评价");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("订单是否删除 0 否 -1 买家删除 -2 卖家删除 1 买家卖家都删除");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .HasColumnName("message")
                    .HasDefaultValueSql("''")
                    .HasComment("买家留言内容");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("购买数量");

                entity.Property(e => e.OrderPercent)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_percent")
                    .HasComment("订单抽成比例");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(255)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("订单编号");

                entity.Property(e => e.Paytime)
                    .HasColumnType("int(11)")
                    .HasColumnName("paytime")
                    .HasComment("订单付款时间");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者联系电话");

                entity.Property(e => e.Postage)
                    .HasPrecision(11, 2)
                    .HasColumnName("postage")
                    .HasComment("邮费");

                entity.Property(e => e.Price)
                    .HasPrecision(11, 2)
                    .HasColumnName("price")
                    .HasComment("商品单价");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者省份");

                entity.Property(e => e.ReceiveTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("receive_time")
                    .HasComment("订单收货时间");

                entity.Property(e => e.RefundEndtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("refund_endtime")
                    .HasComment("订单退款处理结束时间");

                entity.Property(e => e.RefundShopResult)
                    .HasColumnName("refund_shop_result")
                    .HasComment("退款时卖家处理结果 0 未处理 -1 拒绝 1 同意");

                entity.Property(e => e.RefundStarttime)
                    .HasColumnType("int(11)")
                    .HasColumnName("refund_starttime")
                    .HasComment("订单发起退款时间");

                entity.Property(e => e.RefundStatus)
                    .HasColumnName("refund_status")
                    .HasComment("退款处理结果 -2取消申请 -1 失败 0 处理中 1 成功 ");

                entity.Property(e => e.SettlementTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("settlement_time")
                    .HasComment("订单结算时间（款项打给卖家）");

                entity.Property(e => e.ShipmentTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("shipment_time")
                    .HasComment("订单发货时间");

                entity.Property(e => e.ShopUid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("shop_uid")
                    .HasComment("卖家用户ID");

                entity.Property(e => e.SpecId)
                    .HasColumnType("int(11)")
                    .HasColumnName("spec_id")
                    .HasComment("商品规格ID");

                entity.Property(e => e.SpecName)
                    .HasMaxLength(255)
                    .HasColumnName("spec_name")
                    .HasDefaultValueSql("''")
                    .HasComment("规格名称");

                entity.Property(e => e.SpecThumb)
                    .HasMaxLength(255)
                    .HasColumnName("spec_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("规格封面");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("status")
                    .HasComment("订单状态  -1 已关闭  0 待付款 1 待发货 2 待收货 3 待评价 4 已评价 5 退款");

                entity.Property(e => e.Total)
                    .HasPrecision(11, 2)
                    .HasColumnName("total")
                    .HasComment("商品总价（包含邮费）");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(255)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方订单号");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("订单类型 1 支付宝 2 微信 3 余额");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("购买者ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''")
                    .HasComment("购买者姓名");
            });

            modelBuilder.Entity<CmfShopOrderComment>(entity =>
            {
                entity.ToTable("cmf_shop_order_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Goodsid, e.IsAppend }, "goodsid_isappend");

                entity.HasIndex(e => new { e.Uid, e.Orderid, e.IsAppend }, "uid_orderid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("文字内容");

                entity.Property(e => e.ExpressPoints)
                    .HasColumnName("express_points")
                    .HasComment("物流速度评分");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goodsid")
                    .HasComment("商品ID");

                entity.Property(e => e.IsAnonym)
                    .HasColumnName("is_anonym")
                    .HasComment("是否匿名 0否 1是");

                entity.Property(e => e.IsAppend)
                    .HasColumnName("is_append")
                    .HasComment("是否是追评0 否 1 是");

                entity.Property(e => e.Orderid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("orderid")
                    .HasComment("商品订单ID");

                entity.Property(e => e.QualityPoints)
                    .HasColumnName("quality_points")
                    .HasComment("商品描述评分");

                entity.Property(e => e.ServicePoints)
                    .HasColumnName("service_points")
                    .HasComment("服务态度评分");

                entity.Property(e => e.ShopUid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("shop_uid")
                    .HasComment("店铺用户id");

                entity.Property(e => e.Thumbs)
                    .HasMaxLength(255)
                    .HasColumnName("thumbs")
                    .HasDefaultValueSql("''")
                    .HasComment("评论图片列表");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.VideoThumb)
                    .HasMaxLength(255)
                    .HasColumnName("video_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("视频封面");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(255)
                    .HasColumnName("video_url")
                    .HasDefaultValueSql("''")
                    .HasComment("视频地址");
            });

            modelBuilder.Entity<CmfShopOrderMessage>(entity =>
            {
                entity.ToTable("cmf_shop_order_message");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Orderid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("orderid");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("消息内容");

                entity.Property(e => e.TitleEn)
                    .HasMaxLength(255)
                    .HasColumnName("title_en")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TitleNam)
                    .HasMaxLength(255)
                    .HasColumnName("title_nam")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("用户身份 0买家 1卖家");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("接受消息用户ID");
            });

            modelBuilder.Entity<CmfShopOrderRefund>(entity =>
            {
                entity.ToTable("cmf_shop_order_refund");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Orderid, e.ShopUid }, "orderid_shopuid");

                entity.HasIndex(e => new { e.Uid, e.Orderid }, "uid_orderid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("''")
                    .HasComment("平台处理账号");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("退款说明");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goodsid")
                    .HasComment("商品ID");

                entity.Property(e => e.Ip)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ip")
                    .HasComment("平台账号ip");

                entity.Property(e => e.IsPlatformInterpose)
                    .HasColumnName("is_platform_interpose")
                    .HasComment("是否平台介入 0 否 1 是");

                entity.Property(e => e.Orderid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("orderid")
                    .HasComment("订单ID");

                entity.Property(e => e.PlatformInterposeDesc)
                    .HasMaxLength(255)
                    .HasColumnName("platform_interpose_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("申请平台介入的详细原因");

                entity.Property(e => e.PlatformInterposeReason)
                    .HasMaxLength(255)
                    .HasColumnName("platform_interpose_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("申请平台介入的理由");

                entity.Property(e => e.PlatformInterposeThumb)
                    .HasMaxLength(255)
                    .HasColumnName("platform_interpose_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("申请平台介入的图片举证");

                entity.Property(e => e.PlatformProcessTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("platform_process_time")
                    .HasComment("平台处理时间");

                entity.Property(e => e.PlatformResult)
                    .HasColumnName("platform_result")
                    .HasComment("平台处理结果 -1 拒绝 0 处理中 1 同意");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason")
                    .HasDefaultValueSql("''")
                    .HasComment("退款原因");

                entity.Property(e => e.ShopProcessNum)
                    .HasColumnName("shop_process_num")
                    .HasComment("店铺驳回次数");

                entity.Property(e => e.ShopProcessTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("shop_process_time")
                    .HasComment("店铺处理时间");

                entity.Property(e => e.ShopResult)
                    .HasColumnName("shop_result")
                    .HasComment("店铺处理结果 -1 拒绝 0 处理中 1 同意");

                entity.Property(e => e.ShopUid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("shop_uid")
                    .HasComment("商家ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("退款处理状态 0 处理中 -1 买家已取消 1 已完成 ");

                entity.Property(e => e.SystemProcessTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("system_process_time")
                    .HasComment("系统自动处理时间");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("退款图片（废弃）");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("退款类型 0 仅退款 1退货退款");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("买家id");
            });

            modelBuilder.Entity<CmfShopOrderRefundList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_shop_order_refund_list");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("处理时间");

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .HasColumnName("desc")
                    .HasDefaultValueSql("''")
                    .HasComment("处理说明");

                entity.Property(e => e.HandleDesc)
                    .HasMaxLength(255)
                    .HasColumnName("handle_desc")
                    .HasDefaultValueSql("''")
                    .HasComment("处理备注说明");

                entity.Property(e => e.Orderid)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("orderid")
                    .HasComment("订单ID");

                entity.Property(e => e.RefuseReason)
                    .HasMaxLength(255)
                    .HasColumnName("refuse_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("卖家拒绝理由");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("处理方 1 买家 2 卖家 3 平台 4 系统");
            });

            modelBuilder.Entity<CmfShopPlatformReason>(entity =>
            {
                entity.ToTable("cmf_shop_platform_reason");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasComment("排序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("原因名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态 0不显示 1 显示");
            });

            modelBuilder.Entity<CmfShopPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_shop_points");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.EvaluateTotal)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("evaluate_total")
                    .HasComment("评价总数");

                entity.Property(e => e.ExpressPointsTotal)
                    .HasColumnType("int(11)")
                    .HasColumnName("express_points_total")
                    .HasComment("物流服务总分");

                entity.Property(e => e.QualityPointsTotal)
                    .HasColumnType("int(11)")
                    .HasColumnName("quality_points_total")
                    .HasComment("店铺商品质量(商品描述)总分");

                entity.Property(e => e.ServicePointsTotal)
                    .HasColumnType("int(11)")
                    .HasColumnName("service_points_total")
                    .HasComment("店铺服务态度总分");

                entity.Property(e => e.ShopUid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("shop_uid")
                    .HasComment("店铺用户ID");
            });

            modelBuilder.Entity<CmfShopRefundReason>(entity =>
            {
                entity.ToTable("cmf_shop_refund_reason");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasComment("排序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("原因名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态 0不显示 1 显示");
            });

            modelBuilder.Entity<CmfShopRefuseReason>(entity =>
            {
                entity.ToTable("cmf_shop_refuse_reason");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Edittime)
                    .HasColumnType("int(11)")
                    .HasColumnName("edittime")
                    .HasComment("修改时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasComment("排序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("原因名称");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态 0不显示 1 显示");
            });

            modelBuilder.Entity<CmfSlide>(entity =>
            {
                entity.ToTable("cmf_slide");

                entity.HasComment("幻灯片表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("delete_time")
                    .HasComment("删除时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("幻灯片分类")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("''")
                    .HasComment("分类备注")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:显示,0不显示");
            });

            modelBuilder.Entity<CmfSlideCat>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_slide_cat");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.CatIdname, "cat_idname")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 191 });

                entity.Property(e => e.Cid)
                    .HasColumnType("int(11)")
                    .HasColumnName("cid");

                entity.Property(e => e.CatIdname)
                    .HasColumnName("cat_idname")
                    .HasComment("幻灯片分类标识");

                entity.Property(e => e.CatName)
                    .HasMaxLength(255)
                    .HasColumnName("cat_name")
                    .HasComment("幻灯片分类");

                entity.Property(e => e.CatRemark)
                    .HasColumnType("text")
                    .HasColumnName("cat_remark")
                    .HasComment("分类备注");

                entity.Property(e => e.CatStatus)
                    .HasColumnType("int(2)")
                    .HasColumnName("cat_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1显示，0不显示");
            });

            modelBuilder.Entity<CmfSlideItem>(entity =>
            {
                entity.ToTable("cmf_slide_item");

                entity.HasComment("幻灯片子项表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.SlideId, "slide_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("幻灯片内容")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("幻灯片描述")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("''")
                    .HasComment("幻灯片图片")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展信息");

                entity.Property(e => e.SlideId)
                    .HasColumnType("int(11)")
                    .HasColumnName("slide_id")
                    .HasComment("幻灯片id");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态,1:显示;0:隐藏");

                entity.Property(e => e.Target)
                    .HasMaxLength(10)
                    .HasColumnName("target")
                    .HasDefaultValueSql("''")
                    .HasComment("友情链接打开方式");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("幻灯片名称");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''")
                    .HasComment("幻灯片链接")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<CmfSomething>(entity =>
            {
                entity.ToTable("cmf_something");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime");

                entity.Property(e => e.Fabulous)
                    .HasColumnType("int(11)")
                    .HasColumnName("fabulous")
                    .HasComment("点赞数");

                entity.Property(e => e.Pic)
                    .HasColumnType("text")
                    .HasColumnName("pic")
                    .HasComment("图片");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text")
                    .HasComment("文字内容");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfTask>(entity =>
            {
                entity.ToTable("cmf_task");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasComment("发布时间");

                entity.Property(e => e.Money)
                    .HasMaxLength(32)
                    .HasColumnName("money")
                    .HasComment("发布金额");

                entity.Property(e => e.Proportion)
                    .HasColumnType("int(11)")
                    .HasColumnName("proportion")
                    .HasComment("平台比例，百分比单位");

                entity.Property(e => e.ProportionMoney)
                    .HasMaxLength(11)
                    .HasColumnName("proportion_money")
                    .HasComment("平台扣金额");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否完成 0是 1否");

                entity.Property(e => e.SurplusMoney)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("surplus_money")
                    .HasComment("剩余金额");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text")
                    .HasComment("任务说明");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type")
                    .HasComment("1、关注 2、分享");

                entity.Property(e => e.TypeClass)
                    .HasColumnType("int(11)")
                    .HasColumnName("type_class")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1、直播间 2、短视频");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id")
                    .HasComment("主播ID");

                entity.Property(e => e.VideoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("video_id")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfTerm>(entity =>
            {
                entity.HasKey(e => e.TermId)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_terms");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.TermId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("term_id")
                    .HasComment("分类id");

                entity.Property(e => e.Count)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("分类文章数");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasComment("分类描述");

                entity.Property(e => e.ListTpl)
                    .HasMaxLength(50)
                    .HasColumnName("list_tpl")
                    .HasComment("分类列表模板");

                entity.Property(e => e.Listorder)
                    .HasColumnType("int(5)")
                    .HasColumnName("listorder")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name")
                    .HasComment("分类名称");

                entity.Property(e => e.OneTpl)
                    .HasMaxLength(50)
                    .HasColumnName("one_tpl")
                    .HasComment("分类文章页模板");

                entity.Property(e => e.Parent)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent")
                    .HasDefaultValueSql("'0'")
                    .HasComment("分类父id");

                entity.Property(e => e.Path)
                    .HasMaxLength(500)
                    .HasColumnName("path")
                    .HasComment("分类层级关系路径");

                entity.Property(e => e.SeoDescription)
                    .HasMaxLength(500)
                    .HasColumnName("seo_description");

                entity.Property(e => e.SeoKeywords)
                    .HasMaxLength(500)
                    .HasColumnName("seo_keywords");

                entity.Property(e => e.SeoTitle)
                    .HasMaxLength(500)
                    .HasColumnName("seo_title");

                entity.Property(e => e.Slug)
                    .HasMaxLength(200)
                    .HasColumnName("slug")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1发布，0不发布");

                entity.Property(e => e.Taxonomy)
                    .HasMaxLength(32)
                    .HasColumnName("taxonomy")
                    .HasComment("分类类型");
            });

            modelBuilder.Entity<CmfTermRelationship>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_term_relationships");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TermId, "term_taxonomy_id");

                entity.Property(e => e.Tid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("tid");

                entity.Property(e => e.Listorder)
                    .HasColumnType("int(10)")
                    .HasColumnName("listorder")
                    .HasComment("排序");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("object_id")
                    .HasComment("posts表里文章id");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态，1发布，0不发布");

                entity.Property(e => e.TermId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("term_id")
                    .HasComment("分类id");
            });

            modelBuilder.Entity<CmfTheDetail>(entity =>
            {
                entity.ToTable("cmf_the_detail");

                entity.HasComment("发布任务钻石明细")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("coin")
                    .HasComment("获得钻石");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("endtime")
                    .HasComment("完成时间");

                entity.Property(e => e.TaskId)
                    .HasColumnType("int(11)")
                    .HasColumnName("task_id")
                    .HasComment("任务ID");

                entity.Property(e => e.UserId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id")
                    .HasComment("领取任务人ID");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("userid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfTheme>(entity =>
            {
                entity.ToTable("cmf_theme");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(20)
                    .HasColumnName("author")
                    .HasDefaultValueSql("''")
                    .HasComment("主题作者");

                entity.Property(e => e.AuthorUrl)
                    .HasMaxLength(50)
                    .HasColumnName("author_url")
                    .HasDefaultValueSql("''")
                    .HasComment("作者网站链接");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("安装时间");

                entity.Property(e => e.DemoUrl)
                    .HasMaxLength(50)
                    .HasColumnName("demo_url")
                    .HasDefaultValueSql("''")
                    .HasComment("演示地址，带协议");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("主题描述");

                entity.Property(e => e.IsCompiled)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("is_compiled")
                    .HasComment("是否为已编译模板");

                entity.Property(e => e.Keywords)
                    .HasMaxLength(50)
                    .HasColumnName("keywords")
                    .HasDefaultValueSql("''")
                    .HasComment("主题关键字");

                entity.Property(e => e.Lang)
                    .HasMaxLength(10)
                    .HasColumnName("lang")
                    .HasDefaultValueSql("''")
                    .HasComment("支持语言");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("主题名称");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasComment("模板状态,1:正在使用;0:未使用");

                entity.Property(e => e.Theme)
                    .HasMaxLength(20)
                    .HasColumnName("theme")
                    .HasDefaultValueSql("''")
                    .HasComment("主题目录名，用于主题的维一标识");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(100)
                    .HasColumnName("thumbnail")
                    .HasDefaultValueSql("''")
                    .HasComment("缩略图");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("update_time")
                    .HasComment("最后升级时间");

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''")
                    .HasComment("主题版本号");
            });

            modelBuilder.Entity<CmfThemeFile>(entity =>
            {
                entity.ToTable("cmf_theme_file");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("操作");

                entity.Property(e => e.ConfigMore)
                    .HasColumnType("text")
                    .HasColumnName("config_more")
                    .HasComment("模板更多配置,来源模板的配置文件");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("模板文件描述");

                entity.Property(e => e.DraftMore)
                    .HasColumnType("text")
                    .HasColumnName("draft_more")
                    .HasComment("模板更多配置,用户临时保存的配置");

                entity.Property(e => e.File)
                    .HasMaxLength(50)
                    .HasColumnName("file")
                    .HasDefaultValueSql("''")
                    .HasComment("模板文件，相对于模板根目录，如Portal/index.html");

                entity.Property(e => e.IsPublic)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("is_public")
                    .HasComment("是否公共的模板文件");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'10000'")
                    .HasComment("排序");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("模板更多配置,用户自己后台设置的");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("模板文件名");

                entity.Property(e => e.Theme)
                    .HasMaxLength(20)
                    .HasColumnName("theme")
                    .HasDefaultValueSql("''")
                    .HasComment("模板名称");
            });

            modelBuilder.Entity<CmfThirdPartyUser>(entity =>
            {
                entity.ToTable("cmf_third_party_user");

                entity.HasComment("第三方用户表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(512)
                    .HasColumnName("access_token")
                    .HasDefaultValueSql("''")
                    .HasComment("第三方授权码");

                entity.Property(e => e.AppId)
                    .HasMaxLength(64)
                    .HasColumnName("app_id")
                    .HasDefaultValueSql("''")
                    .HasComment("第三方应用 id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("绑定时间");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("expire_time")
                    .HasComment("access_token过期时间");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(15)
                    .HasColumnName("last_login_ip")
                    .HasDefaultValueSql("''")
                    .HasComment("最后登录ip");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_login_time")
                    .HasComment("最后登录时间");

                entity.Property(e => e.LoginTimes)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("login_times")
                    .HasComment("登录次数");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展信息");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname")
                    .HasDefaultValueSql("''")
                    .HasComment("用户昵称");

                entity.Property(e => e.Openid)
                    .HasMaxLength(40)
                    .HasColumnName("openid")
                    .HasDefaultValueSql("''")
                    .HasComment("第三方用户id");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态;1:正常;0:禁用");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(20)
                    .HasColumnName("third_party")
                    .HasDefaultValueSql("''")
                    .HasComment("第三方唯一码");

                entity.Property(e => e.UnionId)
                    .HasMaxLength(64)
                    .HasColumnName("union_id")
                    .HasDefaultValueSql("''")
                    .HasComment("第三方用户多个产品中的惟一 id,(如:微信平台)");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("本站用户id");
            });

            modelBuilder.Entity<CmfTurntable>(entity =>
            {
                entity.ToTable("cmf_turntable");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Rate)
                    .HasPrecision(10, 3)
                    .HasColumnName("rate")
                    .HasComment("中奖率");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图片");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型，0无奖1钻石2礼物");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("''")
                    .HasComment("类型值");

                entity.Property(e => e.Uptime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uptime")
                    .HasComment("时间");
            });

            modelBuilder.Entity<CmfTurntableCon>(entity =>
            {
                entity.ToTable("cmf_turntable_con");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("价格");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Times)
                    .HasColumnType("int(11)")
                    .HasColumnName("times")
                    .HasComment("次数");
            });

            modelBuilder.Entity<CmfTurntableLog>(entity =>
            {
                entity.ToTable("cmf_turntable_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("价格");

                entity.Property(e => e.Iswin)
                    .HasColumnName("iswin")
                    .HasComment("是否中奖");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Showid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfTurntableWin>(entity =>
            {
                entity.ToTable("cmf_turntable_win");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Logid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("logid")
                    .HasComment("转盘记录ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("处理状态，0未处理1已处理");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("图片");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型，0无奖1钻石2礼物");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("'0'")
                    .HasComment("类型值");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uptime")
                    .HasComment("处理时间");
            });

            modelBuilder.Entity<CmfUser>(entity =>
            {
                entity.ToTable("cmf_users");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.Ishot, e.Isrecommend }, "index_ishot_isrecommend");

                entity.HasIndex(e => e.UserLogin, "user_login")
                    .IsUnique();

                entity.HasIndex(e => e.UserNicename, "user_nicename");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("avatar")
                    .HasDefaultValueSql("''")
                    .HasComment("用户头像");

                entity.Property(e => e.AvatarThumb)
                    .HasMaxLength(255)
                    .HasColumnName("avatar_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("小头像");

                entity.Property(e => e.Birthday)
                    .HasMaxLength(50)
                    .HasColumnName("birthday")
                    .HasDefaultValueSql("''")
                    .HasComment("生日");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Coin)
                    .HasColumnType("double(16,2) unsigned")
                    .HasColumnName("coin")
                    .HasComment("金币");

                entity.Property(e => e.Consumption)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("consumption")
                    .HasComment("消费总额");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("注册时间");

                entity.Property(e => e.Expiretime)
                    .HasColumnType("int(12)")
                    .HasColumnName("expiretime")
                    .HasComment("token 到期时间");

                entity.Property(e => e.Goodnum)
                    .HasMaxLength(255)
                    .HasColumnName("goodnum")
                    .HasDefaultValueSql("'0'")
                    .HasComment("当前装备靓号");

                entity.Property(e => e.Ishot)
                    .IsRequired()
                    .HasColumnName("ishot")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否热门显示");

                entity.Property(e => e.Isrecommend)
                    .HasColumnName("isrecommend")
                    .HasComment("0 未推荐 1 推荐");

                entity.Property(e => e.Isrecord)
                    .HasColumnName("isrecord")
                    .HasComment("是否开起回放");

                entity.Property(e => e.Issuper)
                    .HasColumnName("issuper")
                    .HasComment("是否超管");

                entity.Property(e => e.Iszombie)
                    .HasColumnName("iszombie")
                    .HasComment("是否开启僵尸粉");

                entity.Property(e => e.Iszombiep)
                    .HasColumnName("iszombiep")
                    .HasComment("是否僵尸粉");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(16)
                    .HasColumnName("last_login_ip")
                    .HasDefaultValueSql("''")
                    .HasComment("最后登录ip");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_time")
                    .HasComment("最后登录时间");

                entity.Property(e => e.LastSongTime)
                    .HasMaxLength(200)
                    .HasColumnName("last_song_time")
                    .HasComment("最后赠送的次数");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location")
                    .HasDefaultValueSql("''")
                    .HasComment("所在地");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(20)
                    .HasColumnName("login_type")
                    .HasDefaultValueSql("'phone'")
                    .HasComment("注册方式");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .HasComment("手机号");

                entity.Property(e => e.Openid)
                    .HasMaxLength(255)
                    .HasColumnName("openid")
                    .HasDefaultValueSql("''")
                    .HasComment("三方标识");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("用户积分");

                entity.Property(e => e.Sex)
                    .HasColumnType("smallint(1)")
                    .HasColumnName("sex")
                    .HasDefaultValueSql("'2'")
                    .HasComment("性别；0：保密，1：男；2：女");

                entity.Property(e => e.Signature)
                    .HasMaxLength(255)
                    .HasColumnName("signature")
                    .HasDefaultValueSql("''")
                    .HasComment("个性签名")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .HasColumnName("source")
                    .HasDefaultValueSql("'pc'")
                    .HasComment("注册来源");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .HasColumnName("token")
                    .HasDefaultValueSql("''")
                    .HasComment("授权token");

                entity.Property(e => e.TotalWatchVideoCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_watch_video_count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("总的观看次数");

                entity.Property(e => e.UserActivationKey)
                    .HasMaxLength(60)
                    .HasColumnName("user_activation_key")
                    .HasDefaultValueSql("''")
                    .HasComment("激活码");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("user_email")
                    .HasDefaultValueSql("''")
                    .HasComment("登录邮箱");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(60)
                    .HasColumnName("user_login")
                    .HasDefaultValueSql("''")
                    .HasComment("用户名")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.UserNicename)
                    .HasMaxLength(50)
                    .HasColumnName("user_nicename")
                    .HasDefaultValueSql("''")
                    .HasComment("用户美名")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(64)
                    .HasColumnName("user_pass")
                    .HasDefaultValueSql("''")
                    .HasComment("登录密码；sp_password加密");

                entity.Property(e => e.UserStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("用户状态 0：禁用； 1：正常 ；2：未验证");

                entity.Property(e => e.UserType)
                    .HasColumnType("smallint(1)")
                    .HasColumnName("user_type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("用户类型，1:admin ;2:会员");

                entity.Property(e => e.UserUrl)
                    .HasMaxLength(100)
                    .HasColumnName("user_url")
                    .HasDefaultValueSql("''")
                    .HasComment("用户个人网站");

                entity.Property(e => e.Votes)
                    .HasColumnType("decimal(20,2) unsigned")
                    .HasColumnName("votes")
                    .HasComment("映票余额");

                entity.Property(e => e.Votestotal)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("votestotal")
                    .HasComment("映票总额");
            });

            modelBuilder.Entity<CmfUser1>(entity =>
            {
                entity.ToTable("cmf_user");

                entity.HasComment("用户表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserLogin, "user_login");

                entity.HasIndex(e => e.UserNicename, "user_nicename");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(32)
                    .HasColumnName("area")
                    .HasComment("地区");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("avatar")
                    .HasDefaultValueSql("''")
                    .HasComment("用户头像");

                entity.Property(e => e.AvatarThumb)
                    .HasMaxLength(255)
                    .HasColumnName("avatar_thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("小头像");

                entity.Property(e => e.Balance)
                    .HasPrecision(20, 2)
                    .HasColumnName("balance")
                    .HasComment("用户商城人民币账户金额");

                entity.Property(e => e.BalanceConsumption)
                    .HasPrecision(20, 2)
                    .HasColumnName("balance_consumption")
                    .HasComment("用户商城累计消费人民币");

                entity.Property(e => e.BalanceTotal)
                    .HasPrecision(20, 2)
                    .HasColumnName("balance_total")
                    .HasComment("用户商城累计收入人民币");

                entity.Property(e => e.Birthday)
                    .HasColumnType("int(11)")
                    .HasColumnName("birthday")
                    .HasComment("生日");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Coin)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("coin")
                    .HasComment("金币");

                entity.Property(e => e.Consumption)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("consumption")
                    .HasComment("消费总额");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("create_time")
                    .HasComment("注册时间");

                entity.Property(e => e.Education)
                    .HasColumnType("text")
                    .HasColumnName("education")
                    .HasComment("教育json");

                entity.Property(e => e.EndBantime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("end_bantime")
                    .HasComment("禁用到期时间");

                entity.Property(e => e.Goodnum)
                    .HasMaxLength(255)
                    .HasColumnName("goodnum")
                    .HasDefaultValueSql("'0'")
                    .HasComment("当前装备靓号");

                entity.Property(e => e.Ishot)
                    .IsRequired()
                    .HasColumnName("ishot")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否热门显示");

                entity.Property(e => e.Isrecommend)
                    .HasColumnName("isrecommend")
                    .HasComment("0 未推荐 1 推荐");

                entity.Property(e => e.Isrecord)
                    .HasColumnName("isrecord")
                    .HasComment("是否开起回放");

                entity.Property(e => e.Issuper)
                    .HasColumnName("issuper")
                    .HasComment("是否超管");

                entity.Property(e => e.Iszombie)
                    .HasColumnName("iszombie")
                    .HasComment("是否开启僵尸粉");

                entity.Property(e => e.Iszombiep)
                    .HasColumnName("iszombiep")
                    .HasComment("是否僵尸粉");

                entity.Property(e => e.Je)
                    .HasPrecision(22, 2)
                    .HasColumnName("je");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(15)
                    .HasColumnName("last_login_ip")
                    .HasDefaultValueSql("''")
                    .HasComment("最后登录ip");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("last_login_time")
                    .HasComment("最后登录时间");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location")
                    .HasDefaultValueSql("''")
                    .HasComment("所在地");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(20)
                    .HasColumnName("login_type")
                    .HasDefaultValueSql("'phone'")
                    .HasComment("注册方式");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .HasComment("中国手机不带国家代码，国际手机号格式为：国家代码-手机号");

                entity.Property(e => e.More)
                    .HasColumnType("text")
                    .HasColumnName("more")
                    .HasComment("扩展属性");

                entity.Property(e => e.Openid)
                    .HasMaxLength(255)
                    .HasColumnName("openid")
                    .HasDefaultValueSql("''")
                    .HasComment("三方标识");

                entity.Property(e => e.Professional)
                    .HasColumnType("text")
                    .HasColumnName("professional")
                    .HasComment("职业json");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Score)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("score")
                    .HasComment("用户积分");

                entity.Property(e => e.Sex)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("sex")
                    .HasComment("性别;0:保密,1:男,2:女");

                entity.Property(e => e.Signature)
                    .HasMaxLength(255)
                    .HasColumnName("signature")
                    .HasDefaultValueSql("''")
                    .HasComment("个性签名");

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .HasColumnName("source")
                    .HasDefaultValueSql("'pc'")
                    .HasComment("注册来源");

                entity.Property(e => e.Url1)
                    .HasColumnType("text")
                    .HasColumnName("url1")
                    .HasComment("多图片");

                entity.Property(e => e.UserActivationKey)
                    .HasMaxLength(60)
                    .HasColumnName("user_activation_key")
                    .HasDefaultValueSql("''")
                    .HasComment("激活码");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("user_email")
                    .HasDefaultValueSql("''")
                    .HasComment("用户登录邮箱");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(60)
                    .HasColumnName("user_login")
                    .HasDefaultValueSql("''")
                    .HasComment("用户名")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserNicename)
                    .HasMaxLength(50)
                    .HasColumnName("user_nicename")
                    .HasDefaultValueSql("''")
                    .HasComment("用户昵称")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(64)
                    .HasColumnName("user_pass")
                    .HasDefaultValueSql("''")
                    .HasComment("登录密码;cmf_password加密");

                entity.Property(e => e.UserStatus)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("user_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("用户状态;0:禁用,1:正常,2:未验证");

                entity.Property(e => e.UserType)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("user_type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("用户类型;1:admin;2:会员");

                entity.Property(e => e.UserUrl)
                    .HasMaxLength(100)
                    .HasColumnName("user_url")
                    .HasDefaultValueSql("''")
                    .HasComment("用户个人网址");

                entity.Property(e => e.Votes)
                    .HasColumnType("decimal(20,2) unsigned")
                    .HasColumnName("votes")
                    .HasComment("映票余额");

                entity.Property(e => e.Votestotal)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("votestotal")
                    .HasComment("映票总额");
            });

            modelBuilder.Entity<CmfUserAction>(entity =>
            {
                entity.ToTable("cmf_user_action");

                entity.HasComment("用户操作表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("用户操作名称");

                entity.Property(e => e.App)
                    .HasMaxLength(50)
                    .HasColumnName("app")
                    .HasDefaultValueSql("''")
                    .HasComment("操作所在应用名或插件名等");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("更改金币，可以为负");

                entity.Property(e => e.CycleTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("cycle_time")
                    .HasComment("周期时间值");

                entity.Property(e => e.CycleType)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasColumnName("cycle_type")
                    .HasComment("周期类型;0:不限;1:按天;2:按小时;3:永久");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("用户操作名称");

                entity.Property(e => e.RewardNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("reward_number")
                    .HasComment("奖励次数");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("更改积分，可以为负");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url")
                    .HasComment("执行操作的url");
            });

            modelBuilder.Entity<CmfUserActionLog>(entity =>
            {
                entity.ToTable("cmf_user_action_log");

                entity.HasComment("访问记录表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.UserId, e.Object, e.Action }, "user_object_action");

                entity.HasIndex(e => new { e.UserId, e.Object, e.Action, e.Ip }, "user_object_action_ip");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("操作名称;格式:应用名+控制器+操作名,也可自己定义格式只要不发生冲突且惟一;");

                entity.Property(e => e.Count)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("count")
                    .HasComment("访问次数");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''")
                    .HasComment("用户ip");

                entity.Property(e => e.LastVisitTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_visit_time")
                    .HasComment("最后访问时间");

                entity.Property(e => e.Object)
                    .HasMaxLength(100)
                    .HasColumnName("object")
                    .HasDefaultValueSql("''")
                    .HasComment("访问对象的id,格式:不带前缀的表名+id;如posts1表示xx_posts表里id为1的记录");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfUserAttention>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_user_attention");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("关注人ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUserAuth>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_user_auth");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.BackView)
                    .HasMaxLength(255)
                    .HasColumnName("back_view")
                    .HasDefaultValueSql("''")
                    .HasComment("反面");

                entity.Property(e => e.CerNo)
                    .HasMaxLength(50)
                    .HasColumnName("cer_no")
                    .HasDefaultValueSql("''")
                    .HasComment("身份证号");

                entity.Property(e => e.FrontView)
                    .HasMaxLength(255)
                    .HasColumnName("front_view")
                    .HasDefaultValueSql("''")
                    .HasComment("正面");

                entity.Property(e => e.HandsetView)
                    .HasMaxLength(255)
                    .HasColumnName("handset_view")
                    .HasDefaultValueSql("''")
                    .HasComment("手持");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .HasComment("电话");

                entity.Property(e => e.RealName)
                    .HasMaxLength(50)
                    .HasColumnName("real_name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Reason)
                    .HasColumnType("text")
                    .HasColumnName("reason")
                    .HasComment("审核说明");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态 0 处理中 1 成功 2 失败");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(12)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUserBalanceCashrecord>(entity =>
            {
                entity.ToTable("cmf_user_balance_cashrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("帐号");

                entity.Property(e => e.AccountBank)
                    .HasMaxLength(255)
                    .HasColumnName("account_bank")
                    .HasDefaultValueSql("''")
                    .HasComment("银行名称");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.Money)
                    .HasPrecision(20, 2)
                    .HasColumnName("money")
                    .HasComment("提现金额");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(50)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("订单号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0审核中，1审核通过，2审核拒绝");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(100)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方订单号");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("账号类型 1 支付宝 2 微信 3 银行卡");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUserBalanceLog>(entity =>
            {
                entity.ToTable("cmf_user_balance_log");

                entity.HasComment("用户余额变更日志表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Balance)
                    .HasPrecision(10, 2)
                    .HasColumnName("balance")
                    .HasComment("更改后余额");

                entity.Property(e => e.Change)
                    .HasPrecision(10, 2)
                    .HasColumnName("change")
                    .HasComment("更改余额");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasComment("描述");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("''")
                    .HasComment("备注");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id")
                    .HasComment("用户 id");
            });

            modelBuilder.Entity<CmfUserBalanceRecord>(entity =>
            {
                entity.ToTable("cmf_user_balance_record");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasComment("收支行为 1 买家使用余额付款 2 系统自动结算货款给卖家  3 卖家超时未发货,退款给买家 4 买家发起退款，卖家超时未处理,系统自动退款 5买家发起退款，卖家同意 6 买家发起退款，平台介入后同意 7 用户使用余额购买付费项目  8 付费项目收入");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Balance)
                    .HasPrecision(11, 2)
                    .HasColumnName("balance")
                    .HasComment("操作的余额数");

                entity.Property(e => e.Orderid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("orderid")
                    .HasComment("对应的订单ID");

                entity.Property(e => e.Touid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("touid")
                    .HasComment("对方用户id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("收支类型,0支出1收入");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfUserBanrecord>(entity =>
            {
                entity.ToTable("cmf_user_banrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("提交时间");

                entity.Property(e => e.BanLong)
                    .HasColumnType("int(10)")
                    .HasColumnName("ban_long")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户禁用时长：单位：分钟");

                entity.Property(e => e.BanReason)
                    .HasMaxLength(255)
                    .HasColumnName("ban_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("被禁用原因");

                entity.Property(e => e.EndTime)
                    .HasColumnType("int(10)")
                    .HasColumnName("end_time")
                    .HasDefaultValueSql("'0'")
                    .HasComment("禁用到期时间");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("禁用 用户ID");
            });

            modelBuilder.Entity<CmfUserBlack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_user_black");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("被拉黑人ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUserCoinrecord>(entity =>
            {
                entity.ToTable("cmf_user_coinrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Action, e.Uid, e.Addtime }, "action_uid_addtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasComment("收支行为，1赠送礼物,2弹幕,3登录奖励,4购买VIP,5购买坐骑,6房间扣费,7计时扣费,8发送红包,9抢红包,10开通守护,11注册奖励,12礼物中奖,13奖池中奖,14缴纳保证金,15退还保证金,16转盘游戏,17转盘中奖,18购买靓号");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Giftcount)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftcount")
                    .HasComment("数量");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftid")
                    .HasComment("行为对应ID");

                entity.Property(e => e.Mark)
                    .HasColumnName("mark")
                    .HasComment("标识，1表示热门礼物，2表示守护礼物");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(12)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasComment("是否结算");

                entity.Property(e => e.Totalcoin)
                    .HasColumnType("int(20)")
                    .HasColumnName("totalcoin")
                    .HasComment("总价");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(20)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("收支类型,0支出1收入");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUserFavorite>(entity =>
            {
                entity.ToTable("cmf_user_favorite");

                entity.HasComment("用户收藏表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserId, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("'0'")
                    .HasComment("收藏时间");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("收藏内容的描述");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("object_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("收藏内容原来的主键id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''")
                    .HasComment("收藏实体以前所在表,不带前缀");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(100)
                    .HasColumnName("thumbnail")
                    .HasDefaultValueSql("''")
                    .HasComment("缩略图");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("收藏内容的标题");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasComment("收藏内容的原文地址，JSON格式");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户 id");
            });

            modelBuilder.Entity<CmfUserGoodsVisit>(entity =>
            {
                entity.ToTable("cmf_user_goods_visit");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("int(11)")
                    .HasColumnName("goodsid")
                    .HasComment("商品id");

                entity.Property(e => e.TimeFormat)
                    .HasMaxLength(50)
                    .HasColumnName("time_format")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfUserLike>(entity =>
            {
                entity.ToTable("cmf_user_like");

                entity.HasComment("用户点赞表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserId, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("内容的描述");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("object_id")
                    .HasComment("内容原来的主键id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''")
                    .HasComment("内容以前所在表,不带前缀");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(100)
                    .HasColumnName("thumbnail")
                    .HasDefaultValueSql("''")
                    .HasComment("缩略图");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("内容的标题");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''")
                    .HasComment("内容的原文地址，不带域名");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id")
                    .HasComment("用户 id");
            });

            modelBuilder.Entity<CmfUserLoginAttempt>(entity =>
            {
                entity.ToTable("cmf_user_login_attempt");

                entity.HasComment("用户登录尝试表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(100)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("用户账号,手机号,邮箱或用户名");

                entity.Property(e => e.AttemptTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("attempt_time")
                    .HasComment("尝试登录时间");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''")
                    .HasComment("用户 ip");

                entity.Property(e => e.LockedTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("locked_time")
                    .HasComment("锁定时间");

                entity.Property(e => e.LoginAttempts)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("login_attempts")
                    .HasComment("尝试次数");
            });

            modelBuilder.Entity<CmfUserPushid>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_user_pushid");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Pushid)
                    .HasMaxLength(255)
                    .HasColumnName("pushid")
                    .HasDefaultValueSql("''")
                    .HasComment("用户对应极光registration_id");
            });

            modelBuilder.Entity<CmfUserScoreLog>(entity =>
            {
                entity.ToTable("cmf_user_score_log");

                entity.HasComment("用户操作积分等奖励日志表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("用户操作名称");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("更改金币，可以为负");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("更改积分，可以为负");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id")
                    .HasComment("用户 id");
            });

            modelBuilder.Entity<CmfUserScorerecord>(entity =>
            {
                entity.ToTable("cmf_user_scorerecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Action, e.Uid, e.Addtime }, "action_uid_addtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasComment("收支行为，4购买VIP,5购买坐骑,18购买靓号,21游戏获胜");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.GameAction)
                    .HasColumnName("game_action")
                    .HasComment("游戏类型");

                entity.Property(e => e.Giftcount)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftcount")
                    .HasComment("数量");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftid")
                    .HasComment("行为对应ID");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(12)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Totalcoin)
                    .HasColumnType("int(20)")
                    .HasColumnName("totalcoin")
                    .HasComment("总价");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(20)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("收支类型,0支出1收入");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUserSign>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_user_sign");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.BonusDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus_day")
                    .HasComment("登录天数");

                entity.Property(e => e.BonusTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus_time")
                    .HasComment("更新时间");

                entity.Property(e => e.CountDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("count_day")
                    .HasComment("连续登陆天数");
            });

            modelBuilder.Entity<CmfUserSuper>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_user_super");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");
            });

            modelBuilder.Entity<CmfUserToken>(entity =>
            {
                entity.ToTable("cmf_user_token");

                entity.HasComment("用户客户端登录 token 表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("create_time")
                    .HasComment("创建时间");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(10)
                    .HasColumnName("device_type")
                    .HasDefaultValueSql("''")
                    .HasComment("设备类型;mobile,android,iphone,ipad,web,pc,mac,wxapp");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("expire_time")
                    .HasComment(" 过期时间");

                entity.Property(e => e.Token)
                    .HasMaxLength(64)
                    .HasColumnName("token")
                    .HasDefaultValueSql("''")
                    .HasComment("token");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfUserVoterecord>(entity =>
            {
                entity.ToTable("cmf_user_voterecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Action, e.Uid, e.Addtime }, "action_uid_addtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasComment("收支行为,1收礼物2弹幕3分销收益4家族长收益6房间收费7计时收费10守护");

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("actionid")
                    .HasComment("行为对应ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Fromid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fromid")
                    .HasComment("来源用户ID");

                entity.Property(e => e.Nums)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.Showid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total")
                    .HasComment("总价");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("收支类型,0支出，1收入");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Votes)
                    .HasPrecision(20, 2)
                    .HasColumnName("votes")
                    .HasComment("收益映票");
            });

            modelBuilder.Entity<CmfUserZombie>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_user_zombie");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersAgent>(entity =>
            {
                entity.ToTable("cmf_users_agent");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.OneUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("one_uid")
                    .HasComment("上级用户id");

                entity.Property(e => e.ThreeUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("three_uid")
                    .HasComment("上上上级id");

                entity.Property(e => e.TwoUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("two_uid")
                    .HasComment("上上级id");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户id");
            });

            modelBuilder.Entity<CmfUsersAgentCode>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_agent_code");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code")
                    .HasDefaultValueSql("''")
                    .HasComment("邀请码");
            });

            modelBuilder.Entity<CmfUsersAgentProfit>(entity =>
            {
                entity.ToTable("cmf_users_agent_profit");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.OneProfit)
                    .HasColumnName("one_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("一级收益");

                entity.Property(e => e.ThreeProfit)
                    .HasColumnName("three_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("三级收益");

                entity.Property(e => e.TwoProfit)
                    .HasColumnName("two_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("二级收益");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersAgentProfitRecode>(entity =>
            {
                entity.ToTable("cmf_users_agent_profit_recode");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Uid, "uid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasComment("消费类型");

                entity.Property(e => e.OneProfit)
                    .HasColumnName("one_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("一级代理收益");

                entity.Property(e => e.OneUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("one_uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("一级ID");

                entity.Property(e => e.ThreeProfit)
                    .HasColumnName("three_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("三级代理收益");

                entity.Property(e => e.ThreeUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("three_uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("三级ID");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'")
                    .HasComment("消费总数");

                entity.Property(e => e.TwoProfit)
                    .HasColumnName("two_profit")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("二级代理收益");

                entity.Property(e => e.TwoUid)
                    .HasColumnType("int(11)")
                    .HasColumnName("two_uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("二级ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersAttention>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_users_attention");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("关注人ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersAuth>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_auth");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.BackView)
                    .HasMaxLength(255)
                    .HasColumnName("back_view")
                    .HasDefaultValueSql("''")
                    .HasComment("反面");

                entity.Property(e => e.CerNo)
                    .HasMaxLength(50)
                    .HasColumnName("cer_no")
                    .HasDefaultValueSql("''")
                    .HasComment("身份证号");

                entity.Property(e => e.FrontView)
                    .HasMaxLength(255)
                    .HasColumnName("front_view")
                    .HasDefaultValueSql("''")
                    .HasComment("正面");

                entity.Property(e => e.HandsetView)
                    .HasMaxLength(255)
                    .HasColumnName("handset_view")
                    .HasDefaultValueSql("''")
                    .HasComment("手持");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .HasComment("电话");

                entity.Property(e => e.RealName)
                    .HasMaxLength(50)
                    .HasColumnName("real_name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Reason)
                    .HasColumnType("text")
                    .HasColumnName("reason")
                    .HasComment("审核说明");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(12)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUsersBlack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_users_black");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("被拉黑人ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersCar>(entity =>
            {
                entity.ToTable("cmf_users_car");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Carid)
                    .HasColumnType("int(11)")
                    .HasColumnName("carid")
                    .HasComment("坐骑ID");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("是否启用");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersCashAccount>(entity =>
            {
                entity.ToTable("cmf_users_cash_account");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("账号");

                entity.Property(e => e.AccountBank)
                    .HasMaxLength(255)
                    .HasColumnName("account_bank")
                    .HasDefaultValueSql("''")
                    .HasComment("银行名称");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("类型，1表示支付宝，2表示微信，3表示银行卡");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersCashrecord>(entity =>
            {
                entity.ToTable("cmf_users_cashrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("帐号");

                entity.Property(e => e.AccountBank)
                    .HasMaxLength(255)
                    .HasColumnName("account_bank")
                    .HasDefaultValueSql("''")
                    .HasComment("银行名称");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("申请时间");

                entity.Property(e => e.Money)
                    .HasColumnType("int(20)")
                    .HasColumnName("money")
                    .HasComment("提现金额");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("姓名");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(50)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("订单号");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，0审核中，1审核通过，2审核拒绝");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(100)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方订单号");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("账号类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");

                entity.Property(e => e.Votes)
                    .HasColumnType("int(20)")
                    .HasColumnName("votes")
                    .HasComment("提现映票数");
            });

            modelBuilder.Entity<CmfUsersCharge>(entity =>
            {
                entity.ToTable("cmf_users_charge");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Ambient)
                    .HasColumnName("ambient")
                    .HasComment("支付环境");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.CoinGive)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_give")
                    .HasComment("赠送钻石数");

                entity.Property(e => e.Money)
                    .HasPrecision(11, 2)
                    .HasColumnName("money")
                    .HasComment("金额");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(50)
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("''")
                    .HasComment("商家订单号");

                entity.Property(e => e.Pid)
                    .HasColumnType("int(11)")
                    .HasColumnName("pid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("三方支付ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("充值对象ID");

                entity.Property(e => e.TradeNo)
                    .HasMaxLength(100)
                    .HasColumnName("trade_no")
                    .HasDefaultValueSql("''")
                    .HasComment("三方平台订单号");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("支付类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<CmfUsersChargeAdmin>(entity =>
            {
                entity.ToTable("cmf_users_charge_admin");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Admin)
                    .HasMaxLength(255)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("''")
                    .HasComment("管理员");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(20)")
                    .HasColumnName("coin")
                    .HasComment("钻石数");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''")
                    .HasComment("IP");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("充值对象ID");
            });

            modelBuilder.Entity<CmfUsersCoinrecord>(entity =>
            {
                entity.ToTable("cmf_users_coinrecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Action, e.Uid, e.Addtime }, "action_uid_addtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("收支行为");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Giftcount)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftcount")
                    .HasComment("数量");

                entity.Property(e => e.Giftid)
                    .HasColumnType("int(20)")
                    .HasColumnName("giftid")
                    .HasComment("行为对应ID");

                entity.Property(e => e.Mark)
                    .HasColumnName("mark")
                    .HasComment("标识，1表示热门礼物，2表示守护礼物");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(12)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Totalcoin)
                    .HasColumnType("int(20)")
                    .HasColumnName("totalcoin")
                    .HasComment("总价");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(20)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasComment("收支类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersFamily>(entity =>
            {
                entity.ToTable("cmf_users_family");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.DivideFamily)
                    .HasColumnType("int(11)")
                    .HasColumnName("divide_family")
                    .HasDefaultValueSql("'-1'")
                    .HasComment("家族分成");

                entity.Property(e => e.Familyid)
                    .HasColumnType("int(11)")
                    .HasColumnName("familyid")
                    .HasComment("家族ID");

                entity.Property(e => e.Istip)
                    .HasColumnName("istip")
                    .HasComment("审核后是否需要通知");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason")
                    .HasDefaultValueSql("''")
                    .HasComment("原因");

                entity.Property(e => e.Signout)
                    .HasColumnName("signout")
                    .HasComment("是否退出");

                entity.Property(e => e.SignoutIstip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("signout_istip")
                    .HasComment("踢出或拒绝是否需要通知");

                entity.Property(e => e.SignoutReason)
                    .HasMaxLength(255)
                    .HasColumnName("signout_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("踢出或拒绝理由");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasComment("状态");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUsersGamerecord>(entity =>
            {
                entity.ToTable("cmf_users_gamerecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏类型");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("下注时间");

                entity.Property(e => e.Coin1)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_1")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1位置下注金额");

                entity.Property(e => e.Coin2)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_2")
                    .HasDefaultValueSql("'0'")
                    .HasComment("2位置下注金额");

                entity.Property(e => e.Coin3)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_3")
                    .HasDefaultValueSql("'0'")
                    .HasComment("3位置下注金额");

                entity.Property(e => e.Coin4)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_4")
                    .HasDefaultValueSql("'0'")
                    .HasComment("4位置下注金额");

                entity.Property(e => e.Coin5)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_5")
                    .HasDefaultValueSql("'0'")
                    .HasComment("5位置下注金额");

                entity.Property(e => e.Coin6)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin_6")
                    .HasDefaultValueSql("'0'")
                    .HasComment("6位置下注金额");

                entity.Property(e => e.Gameid)
                    .HasColumnType("int(11)")
                    .HasColumnName("gameid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("游戏ID");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveuid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("主播ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("处理状态 0 未处理 1 已处理");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersLabel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_users_label");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Touid, "touid");

                entity.HasIndex(e => e.Uid, "uid");

                entity.HasIndex(e => new { e.Uid, e.Touid }, "uid_touid_index");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Label)
                    .HasMaxLength(255)
                    .HasColumnName("label")
                    .HasDefaultValueSql("''")
                    .HasComment("选择的标签");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUsersLaravelPayLog>(entity =>
            {
                entity.ToTable("cmf_users_laravel_pay_log");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PayLog)
                    .HasColumnType("text")
                    .HasColumnName("pay_log");
            });

            modelBuilder.Entity<CmfUsersLive>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_live");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Islive, e.Starttime }, "index_islive_starttime");

                entity.HasIndex(e => new { e.Uid, e.Stream }, "index_uid_stream")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 191 });

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Anyway)
                    .IsRequired()
                    .HasColumnName("anyway")
                    .HasDefaultValueSql("'1'")
                    .HasComment("横竖屏，0表示竖屏，1表示横屏");

                entity.Property(e => e.BcType)
                    .HasMaxLength(32)
                    .HasColumnName("bc_type")
                    .HasComment("彩票类型");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Deviceinfo)
                    .HasMaxLength(255)
                    .HasColumnName("deviceinfo")
                    .HasDefaultValueSql("''")
                    .HasComment("设备信息");

                entity.Property(e => e.Goodnum)
                    .HasMaxLength(255)
                    .HasColumnName("goodnum")
                    .HasDefaultValueSql("'0'")
                    .HasComment("靓号");

                entity.Property(e => e.Hotvotes)
                    .HasColumnType("int(11)")
                    .HasColumnName("hotvotes")
                    .HasComment("热门礼物总额");

                entity.Property(e => e.Ishot)
                    .HasColumnName("ishot")
                    .HasComment("是否热门");

                entity.Property(e => e.Islive)
                    .HasColumnType("int(1)")
                    .HasColumnName("islive")
                    .HasComment("直播状态");

                entity.Property(e => e.Ismic)
                    .HasColumnName("ismic")
                    .HasComment("连麦开关，0是关，1是开");

                entity.Property(e => e.Isrecommend)
                    .HasColumnName("isrecommend")
                    .HasComment("是否推荐");

                entity.Property(e => e.Isshop)
                    .HasColumnName("isshop")
                    .HasComment("是否开启店铺");

                entity.Property(e => e.Isvideo)
                    .HasColumnName("isvideo")
                    .HasComment("是否假视频");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("维度");

                entity.Property(e => e.Liveclassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveclassid")
                    .HasComment("直播分类ID");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.Pkstream)
                    .HasMaxLength(255)
                    .HasColumnName("pkstream")
                    .HasDefaultValueSql("''")
                    .HasComment("pk对方的流名");

                entity.Property(e => e.Pkuid)
                    .HasColumnType("int(11)")
                    .HasColumnName("pkuid")
                    .HasComment("PK对方ID");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Pull)
                    .HasMaxLength(255)
                    .HasColumnName("pull")
                    .HasDefaultValueSql("''")
                    .HasComment("播流地址");

                entity.Property(e => e.RoomId)
                    .HasColumnType("int(11)")
                    .HasColumnName("room_id")
                    .HasComment("房间ID");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(12)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Starttime)
                    .HasColumnType("int(12)")
                    .HasColumnName("starttime")
                    .HasComment("开播时间");

                entity.Property(e => e.Stream)
                    .HasColumnName("stream")
                    .HasDefaultValueSql("''")
                    .HasComment("流名");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("直播类型");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("''")
                    .HasComment("类型值");

                entity.Property(e => e.WyCid)
                    .HasMaxLength(255)
                    .HasColumnName("wy_cid")
                    .HasDefaultValueSql("''")
                    .HasComment("网易房间ID(当不使用网易是默认为空)");
            });

            modelBuilder.Entity<CmfUsersLivemanager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmf_users_livemanager");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Liveuid, e.Uid }, "uid_touid_index");

                entity.Property(e => e.Liveuid)
                    .HasColumnType("int(12)")
                    .HasColumnName("liveuid")
                    .HasComment("主播ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersLiverecord>(entity =>
            {
                entity.ToTable("cmf_users_liverecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Uid, e.Starttime }, "index_uid_start");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endtime")
                    .HasComment("结束时间");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("纬度");

                entity.Property(e => e.Liveclassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("liveclassid")
                    .HasComment("直播分类ID");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.Nums)
                    .HasColumnType("int(11)")
                    .HasColumnName("nums")
                    .HasComment("关播时人数");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province")
                    .HasDefaultValueSql("''")
                    .HasComment("省份");

                entity.Property(e => e.Showid)
                    .HasColumnType("int(11)")
                    .HasColumnName("showid")
                    .HasComment("直播标识");

                entity.Property(e => e.Starttime)
                    .HasColumnType("int(11)")
                    .HasColumnName("starttime")
                    .HasComment("开始时间");

                entity.Property(e => e.Stream)
                    .HasMaxLength(255)
                    .HasColumnName("stream")
                    .HasDefaultValueSql("''")
                    .HasComment("流名");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图");

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .HasColumnName("time")
                    .HasDefaultValueSql("''")
                    .HasComment("格式日期");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("直播类型");

                entity.Property(e => e.TypeVal)
                    .HasMaxLength(255)
                    .HasColumnName("type_val")
                    .HasDefaultValueSql("''")
                    .HasComment("类型值");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(255)
                    .HasColumnName("video_url")
                    .HasDefaultValueSql("''")
                    .HasComment("回放地址");

                entity.Property(e => e.Votes)
                    .HasMaxLength(255)
                    .HasColumnName("votes")
                    .HasDefaultValueSql("'0'")
                    .HasComment("本次直播收益");
            });

            modelBuilder.Entity<CmfUsersMusic>(entity =>
            {
                entity.ToTable("cmf_users_music");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .HasColumnName("author")
                    .HasDefaultValueSql("''")
                    .HasComment("演唱者");

                entity.Property(e => e.ClassifyId)
                    .HasColumnType("int(12)")
                    .HasColumnName("classify_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("音乐分类ID");

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(255)
                    .HasColumnName("file_url")
                    .HasDefaultValueSql("''")
                    .HasComment("文件地址");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .HasColumnName("img_url")
                    .HasDefaultValueSql("''")
                    .HasComment("封面地址");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否被删除 0否 1是");

                entity.Property(e => e.Length)
                    .HasMaxLength(255)
                    .HasColumnName("length")
                    .HasDefaultValueSql("''")
                    .HasComment("音乐长度");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("音乐名称");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("更新时间");

                entity.Property(e => e.UploadType)
                    .HasColumnName("upload_type")
                    .HasDefaultValueSql("'0'")
                    .HasComment("上传类型  1管理员上传 2 用户上传");

                entity.Property(e => e.Uploader)
                    .HasColumnType("int(255)")
                    .HasColumnName("uploader")
                    .HasDefaultValueSql("'0'")
                    .HasComment("上传者ID");

                entity.Property(e => e.UseNums)
                    .HasColumnType("int(12)")
                    .HasColumnName("use_nums")
                    .HasDefaultValueSql("'0'")
                    .HasComment("被使用次数");
            });

            modelBuilder.Entity<CmfUsersMusicClassify>(entity =>
            {
                entity.ToTable("cmf_users_music_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .HasColumnName("img_url")
                    .HasDefaultValueSql("''")
                    .HasComment("分类图标地址");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否删除");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(12)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序号");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名称");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<CmfUsersMusicCollection>(entity =>
            {
                entity.ToTable("cmf_users_music_collection");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id")
                    .HasComment("自增id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.MusicId)
                    .HasColumnType("int(12)")
                    .HasColumnName("music_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("音乐id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("音乐收藏状态 1收藏 0 取消收藏");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(12)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户id");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("int(12)")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUsersProxy>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_proxy");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''")
                    .HasComment("关系");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("用户类型,0是会员1是代理，-1推广员");
            });

            modelBuilder.Entity<CmfUsersPushid>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_pushid");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Pushid)
                    .HasMaxLength(255)
                    .HasColumnName("pushid")
                    .HasDefaultValueSql("''")
                    .HasComment("用户对应极光registration_id");
            });

            modelBuilder.Entity<CmfUsersReport>(entity =>
            {
                entity.ToTable("cmf_users_report");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("内容");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("对方ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<CmfUsersReportClassify>(entity =>
            {
                entity.ToTable("cmf_users_report_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("举报类型名称")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(10)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序");
            });

            modelBuilder.Entity<CmfUsersSign>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_sign");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.BonusDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus_day")
                    .HasComment("登录天数");

                entity.Property(e => e.BonusTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus_time")
                    .HasComment("更新时间");

                entity.Property(e => e.CountDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("count_day")
                    .HasComment("连续登陆天数");
            });

            modelBuilder.Entity<CmfUsersSuper>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_super");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVideo>(entity =>
            {
                entity.ToTable("cmf_users_video");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AdEndtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("ad_endtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("广告显示到期时间");

                entity.Property(e => e.AdUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ad_url")
                    .HasDefaultValueSql("''")
                    .HasComment("广告外链");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("发布时间");

                entity.Property(e => e.AllVideoUrl)
                    .HasMaxLength(200)
                    .HasColumnName("all_video_url")
                    .HasComment("完整视频地址");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Comments)
                    .HasColumnType("int(11)")
                    .HasColumnName("comments")
                    .HasDefaultValueSql("'0'")
                    .HasComment("评论数");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goodsid")
                    .HasComment("商品ID");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("视频地址");

                entity.Property(e => e.IsAd)
                    .HasColumnName("is_ad")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否为广告视频 0 否 1 是");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否删除 1删除（下架）0不下架");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("维度");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasDefaultValueSql("'0'")
                    .HasComment("点赞数");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.MusicId)
                    .HasColumnType("int(12)")
                    .HasColumnName("music_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("背景音乐ID");

                entity.Property(e => e.NopassTime)
                    .HasColumnType("int(12)")
                    .HasColumnName("nopass_time")
                    .HasDefaultValueSql("'0'")
                    .HasComment("审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(12)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("权重值，数字越大越靠前");

                entity.Property(e => e.Shares)
                    .HasColumnType("int(11)")
                    .HasColumnName("shares")
                    .HasDefaultValueSql("'0'")
                    .HasComment("分享数量");

                entity.Property(e => e.ShowVal)
                    .HasColumnType("int(12)")
                    .HasColumnName("show_val")
                    .HasDefaultValueSql("'0'")
                    .HasComment("曝光值");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("视频状态 0未审核 1通过 2拒绝");

                entity.Property(e => e.Steps)
                    .HasColumnType("int(11)")
                    .HasColumnName("steps")
                    .HasDefaultValueSql("'0'")
                    .HasComment("踩总数");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图片");

                entity.Property(e => e.ThumbS)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_s")
                    .HasDefaultValueSql("''")
                    .HasComment("封面小图");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoclassid)
                    .HasColumnType("int(11)")
                    .HasColumnName("videoclassid")
                    .HasComment("视频ID");

                entity.Property(e => e.Views)
                    .HasColumnType("int(11)")
                    .HasColumnName("views")
                    .HasDefaultValueSql("'1'")
                    .HasComment("浏览数（涉及到推荐排序机制，所以默认为1）");

                entity.Property(e => e.WatchOk)
                    .HasColumnType("int(12)")
                    .HasColumnName("watch_ok")
                    .HasDefaultValueSql("'1'")
                    .HasComment("视频完整看完次数(涉及到推荐排序机制，所以默认为1)");

                entity.Property(e => e.XiajiaReason)
                    .HasMaxLength(255)
                    .HasColumnName("xiajia_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("下架原因");
            });

            modelBuilder.Entity<CmfUsersVideoBlack>(entity =>
            {
                entity.ToTable("cmf_users_video_black");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVideoComment>(entity =>
            {
                entity.ToTable("cmf_users_video_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AtInfo)
                    .HasMaxLength(255)
                    .HasColumnName("at_info")
                    .HasDefaultValueSql("''")
                    .HasComment("评论时被@用户的信息（json串）");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasDefaultValueSql("'0'")
                    .HasComment("点赞数");

                entity.Property(e => e.Parentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("parentid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(10)")
                    .HasColumnName("touid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVideoCommentsLike>(entity =>
            {
                entity.ToTable("cmf_users_video_comments_like");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("被喜欢的评论者id");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(12)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("评论所属视频id");
            });

            modelBuilder.Entity<CmfUsersVideoLike>(entity =>
            {
                entity.ToTable("cmf_users_video_like");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("视频是否被删除或被拒绝 0被删除或被拒绝 1 正常");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVideoReport>(entity =>
            {
                entity.ToTable("cmf_users_video_report");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0处理中 1已处理  2审核失败");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(11)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfUsersVideoReportClassify>(entity =>
            {
                entity.ToTable("cmf_users_video_report_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("举报类型名称")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(10)")
                    .HasColumnName("orderno")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序");
            });

            modelBuilder.Entity<CmfUsersVideoStep>(entity =>
            {
                entity.ToTable("cmf_users_video_step");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVideoView>(entity =>
            {
                entity.ToTable("cmf_users_video_view");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CmfUsersVip>(entity =>
            {
                entity.ToTable("cmf_users_vip");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Grade)
                    .HasMaxLength(32)
                    .HasColumnName("grade")
                    .HasComment("等级");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfUsersVoterecord>(entity =>
            {
                entity.ToTable("cmf_users_voterecord");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.Action, e.Uid, e.Addtime }, "action_uid_addtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action")
                    .HasDefaultValueSql("''")
                    .HasComment("收支行为");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasComment("收支类型");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(20)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Votes)
                    .HasPrecision(20, 2)
                    .HasColumnName("votes")
                    .HasComment("收益映票");
            });

            modelBuilder.Entity<CmfUsersZombie>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("cmf_users_zombie");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CmfVerificationCode>(entity =>
            {
                entity.ToTable("cmf_verification_code");

                entity.HasComment("手机邮箱数字验证码表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id")
                    .HasComment("表id");

                entity.Property(e => e.Account)
                    .HasMaxLength(100)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("手机号或者邮箱")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .HasColumnName("code")
                    .HasDefaultValueSql("''")
                    .HasComment("最后发送成功的验证码")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Count)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("count")
                    .HasComment("当天已经发送成功的次数");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("expire_time")
                    .HasComment("验证码过期时间");

                entity.Property(e => e.SendTime)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("send_time")
                    .HasComment("最后发送成功时间");
            });

            modelBuilder.Entity<CmfVideo>(entity =>
            {
                entity.ToTable("cmf_video");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AdEndtime)
                    .HasColumnType("int(12)")
                    .HasColumnName("ad_endtime")
                    .HasComment("广告显示到期时间");

                entity.Property(e => e.AdUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ad_url")
                    .HasDefaultValueSql("''")
                    .HasComment("广告外链");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("发布时间");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("''")
                    .HasComment("城市");

                entity.Property(e => e.Classid)
                    .HasColumnType("int(11)")
                    .HasColumnName("classid")
                    .HasComment("分类ID");

                entity.Property(e => e.Comments)
                    .HasColumnType("int(11)")
                    .HasColumnName("comments")
                    .HasComment("评论数");

                entity.Property(e => e.Goodsid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goodsid")
                    .HasComment("商品ID");

                entity.Property(e => e.Href)
                    .HasMaxLength(255)
                    .HasColumnName("href")
                    .HasDefaultValueSql("''")
                    .HasComment("视频地址");

                entity.Property(e => e.HrefW)
                    .HasMaxLength(255)
                    .HasColumnName("href_w")
                    .HasDefaultValueSql("''")
                    .HasComment("水印视频");

                entity.Property(e => e.IsAd)
                    .HasColumnName("is_ad")
                    .HasComment("是否为广告视频 0 否 1 是");

                entity.Property(e => e.Isdel)
                    .HasColumnName("isdel")
                    .HasComment("是否删除 1删除（下架）0不下架");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("''")
                    .HasComment("维度");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasComment("点赞数");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng")
                    .HasDefaultValueSql("''")
                    .HasComment("经度");

                entity.Property(e => e.MusicId)
                    .HasColumnType("int(12)")
                    .HasColumnName("music_id")
                    .HasComment("背景音乐ID");

                entity.Property(e => e.NopassTime)
                    .HasColumnType("int(12)")
                    .HasColumnName("nopass_time")
                    .HasComment("审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）");

                entity.Property(e => e.Orderno)
                    .HasColumnType("int(12)")
                    .HasColumnName("orderno")
                    .HasComment("权重值，数字越大越靠前");

                entity.Property(e => e.Shares)
                    .HasColumnType("int(11)")
                    .HasColumnName("shares")
                    .HasComment("分享数量");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("视频状态 0未审核 1通过 2拒绝");

                entity.Property(e => e.Steps)
                    .HasColumnType("int(11)")
                    .HasColumnName("steps")
                    .HasComment("踩总数");

                entity.Property(e => e.Thumb)
                    .HasMaxLength(255)
                    .HasColumnName("thumb")
                    .HasDefaultValueSql("''")
                    .HasComment("封面图片");

                entity.Property(e => e.ThumbS)
                    .HasMaxLength(255)
                    .HasColumnName("thumb_s")
                    .HasDefaultValueSql("''")
                    .HasComment("封面小图");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type")
                    .HasComment("视频绑定类型 0 未绑定 1 商品  2 付费内容");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Views)
                    .HasColumnType("int(11)")
                    .HasColumnName("views")
                    .HasDefaultValueSql("'1'")
                    .HasComment("浏览数（涉及到推荐排序机制，所以默认为1）");

                entity.Property(e => e.WatchOk)
                    .HasColumnType("int(12)")
                    .HasColumnName("watch_ok")
                    .HasDefaultValueSql("'1'")
                    .HasComment("视频完整看完次数(涉及到推荐排序机制，所以默认为1)");

                entity.Property(e => e.XiajiaReason)
                    .HasMaxLength(255)
                    .HasColumnName("xiajia_reason")
                    .HasDefaultValueSql("''")
                    .HasComment("下架原因");
            });

            modelBuilder.Entity<CmfVideoBlack>(entity =>
            {
                entity.ToTable("cmf_video_black");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVideoClass>(entity =>
            {
                entity.ToTable("cmf_video_class");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("分类名");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam");
            });

            modelBuilder.Entity<CmfVideoComment>(entity =>
            {
                entity.ToTable("cmf_video_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.AtInfo)
                    .HasMaxLength(255)
                    .HasColumnName("at_info")
                    .HasDefaultValueSql("''")
                    .HasComment("评论时被@用户的信息（json串）");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasComment("所属评论ID");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("评论内容");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasComment("点赞数");

                entity.Property(e => e.Parentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("parentid")
                    .HasComment("上级评论ID");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(10)")
                    .HasColumnName("touid")
                    .HasComment("被评论的用户ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("评论用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVideoCommentsLike>(entity =>
            {
                entity.ToTable("cmf_video_comments_like");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Commentid)
                    .HasColumnType("int(10)")
                    .HasColumnName("commentid")
                    .HasComment("评论ID");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(12)")
                    .HasColumnName("touid")
                    .HasComment("被喜欢的评论者id");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(12)")
                    .HasColumnName("videoid")
                    .HasComment("评论所属视频id");
            });

            modelBuilder.Entity<CmfVideoLike>(entity =>
            {
                entity.ToTable("cmf_video_like");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("视频是否被删除或被拒绝 0被删除或被拒绝 1 正常");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVideoReport>(entity =>
            {
                entity.ToTable("cmf_video_report");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("提交时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''")
                    .HasComment("内容");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("0处理中 1已处理  2审核失败");

                entity.Property(e => e.Touid)
                    .HasColumnType("int(11)")
                    .HasColumnName("touid")
                    .HasComment("被举报用户ID");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Uptime)
                    .HasColumnType("int(11)")
                    .HasColumnName("uptime")
                    .HasComment("修改时间");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(11)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVideoReportClassify>(entity =>
            {
                entity.ToTable("cmf_video_report_classify");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(10)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("排序");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("举报类型名称")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en")
                    .HasDefaultValueSql("'a'");

                entity.Property(e => e.NameNam)
                    .HasMaxLength(255)
                    .HasColumnName("name_nam")
                    .HasDefaultValueSql("'b'");
            });

            modelBuilder.Entity<CmfVideoStep>(entity =>
            {
                entity.ToTable("cmf_video_step");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVideoView>(entity =>
            {
                entity.ToTable("cmf_video_view");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("时间");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("int(10)")
                    .HasColumnName("videoid")
                    .HasComment("视频ID");
            });

            modelBuilder.Entity<CmfVip>(entity =>
            {
                entity.ToTable("cmf_vip");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Coin)
                    .HasColumnType("int(11)")
                    .HasColumnName("coin")
                    .HasComment("价格");

                entity.Property(e => e.Length)
                    .HasColumnType("int(11)")
                    .HasColumnName("length")
                    .HasDefaultValueSql("'1'")
                    .HasComment("时长（月）");

                entity.Property(e => e.ListOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("list_order")
                    .HasDefaultValueSql("'9999'")
                    .HasComment("序号");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasComment("名称");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score")
                    .HasComment("积分价格");
            });

            modelBuilder.Entity<CmfVipUser>(entity =>
            {
                entity.ToTable("cmf_vip_user");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("addtime")
                    .HasComment("添加时间");

                entity.Property(e => e.Endtime)
                    .HasColumnType("int(10)")
                    .HasColumnName("endtime")
                    .HasComment("到期时间");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(10)")
                    .HasColumnName("uid")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<CodepayOrder>(entity =>
            {
                entity.ToTable("codepay_order");

                entity.HasComment("用于区分是否已经处理")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.PayId, e.PayTime, e.Money, e.Type, e.PayTag }, "main")
                    .IsUnique();

                entity.HasIndex(e => new { e.PayNo, e.Type }, "pay_no")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatTime)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("creat_time")
                    .HasComment("创建时间");

                entity.Property(e => e.Money)
                    .HasColumnType("decimal(6,2) unsigned")
                    .HasColumnName("money")
                    .HasComment("实际金额");

                entity.Property(e => e.Param)
                    .HasMaxLength(200)
                    .HasColumnName("param")
                    .HasComment("自定义参数");

                entity.Property(e => e.PayId)
                    .HasMaxLength(50)
                    .HasColumnName("pay_id")
                    .HasComment("用户ID或订单ID");

                entity.Property(e => e.PayNo)
                    .HasMaxLength(100)
                    .HasColumnName("pay_no")
                    .HasComment("流水号");

                entity.Property(e => e.PayTag)
                    .HasMaxLength(100)
                    .HasColumnName("pay_tag")
                    .HasDefaultValueSql("'0'")
                    .HasComment("金额的备注");

                entity.Property(e => e.PayTime)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("pay_time")
                    .HasComment("付款时间");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(6,2) unsigned")
                    .HasColumnName("price")
                    .HasComment("原价");

                entity.Property(e => e.Status)
                    .HasColumnType("int(1)")
                    .HasColumnName("status")
                    .HasComment("订单状态");

                entity.Property(e => e.Type)
                    .HasColumnType("int(1)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("支付方式");

                entity.Property(e => e.UpTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("up_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<Foo>(entity =>
            {
                entity.ToTable("foo");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Val)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("val");
            });

            modelBuilder.Entity<V1JiguangUserDatum>(entity =>
            {
                entity.HasKey(e => e.JgId)
                    .HasName("PRIMARY");

                entity.ToTable("v1_jiguang_user_data");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.JgId)
                    .HasColumnType("int(10)")
                    .HasColumnName("jg_id");

                entity.Property(e => e.AppType)
                    .HasMaxLength(200)
                    .HasColumnName("app_type");

                entity.Property(e => e.IsSent)
                    .HasColumnType("int(2)")
                    .HasColumnName("is_sent")
                    .HasDefaultValueSql("'1'")
                    .HasComment("判定是都接受app推送，默认1是推送 2是不推送");

                entity.Property(e => e.JiguangId)
                    .HasMaxLength(200)
                    .HasColumnName("jiguang_id");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(30)
                    .HasColumnName("latitude")
                    .HasComment("纬度");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(30)
                    .HasColumnName("longitude")
                    .HasComment("经度");

                entity.Property(e => e.RegionTag)
                    .HasMaxLength(40)
                    .HasColumnName("region_tag")
                    .HasComment("地区tag");

                entity.Property(e => e.Time)
                    .HasColumnType("int(11)")
                    .HasColumnName("time")
                    .HasComment("登录时间");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10)")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserSex)
                    .HasColumnType("int(2)")
                    .HasColumnName("user_sex")
                    .HasComment("性别 1为男 0为女");
            });

            modelBuilder.Entity<V1MessageTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PRIMARY");

                entity.ToTable("v1_message_task");

                entity.Property(e => e.TaskId)
                    .HasColumnType("int(10)")
                    .HasColumnName("task_id");

                entity.Property(e => e.MessageContent)
                    .HasMaxLength(400)
                    .HasColumnName("message_content")
                    .HasComment("信息内容")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TaskType)
                    .HasMaxLength(100)
                    .HasColumnName("task_type")
                    .HasComment("任务类型")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Time)
                    .HasColumnType("int(11)")
                    .HasColumnName("time")
                    .HasComment("执行时间");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10)")
                    .HasColumnName("user_id")
                    .HasComment("信贷员ID");
            });

            modelBuilder.Entity<V1PushMessageHistory>(entity =>
            {
                entity.HasKey(e => e.PushMessageHistoryId)
                    .HasName("PRIMARY");

                entity.ToTable("v1_push_message_history");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.PushMessageHistoryId)
                    .HasColumnType("int(10)")
                    .HasColumnName("push_message_history_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("推送内容");

                entity.Property(e => e.MsgType)
                    .HasColumnType("int(10)")
                    .HasColumnName("msg_type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("消息类型 1 系统消息  2活动消息 3还款提醒 ");

                entity.Property(e => e.Platform)
                    .HasColumnType("text")
                    .HasColumnName("platform")
                    .HasComment("推送平台");

                entity.Property(e => e.Receiver)
                    .HasColumnType("text")
                    .HasColumnName("receiver")
                    .HasComment("receiver消息标识");

                entity.Property(e => e.Time)
                    .HasColumnType("int(11)")
                    .HasColumnName("time")
                    .HasComment("发布时间");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10)")
                    .HasColumnName("user_id")
                    .HasComment("操作用户");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
