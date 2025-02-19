﻿using System;
using AntiAddictionSDK.Api;
using UnityEngine;

namespace AntiAddictionSDK.Common
{
    public interface IAntiAddictionClient 
    {

        //登录回调
        // 登录成功
        event EventHandler<LoginSuccessEventArgs> OnTouristsModeLoginSuccess;
        // 登录失败
        event EventHandler<EventArgs> OnTouristsModeLoginFailed;
        // 实名认证回调
        //实名认证成功
        event EventHandler<EventArgs> RealNameAuthenticateSuccess;
        //实名认证失败(用户点击暂不认证)
        event EventHandler<EventArgs> RealNameAuthenticateFailed;
        //实名认证失败(用户点击退出游戏)
        event EventHandler<EventArgs> RealNameAuthenticateFailedWithForceExit;
        // 游客时长已用完
        event EventHandler<EventArgs> NoTimeLeftWithTouristsMode;
        // 未成年人时长已用完
        event EventHandler<EventArgs> NoTimeLeftWithNonageMode;
        // 当前用户剩余时间，每秒回调一次
        event EventHandler<LeftTimeEventArgs> LeftTimeOfCurrentUserInEverySeconds;


        // 获取当前用户游客登录状态
        // 0: 已登录
        // 1: 未登录
        int IsLogined();

        // 获取用户实名认证状态
        // 0: 未实名认证
        // 1：已实名认证
        int IsAuthenticated();

        // 获取当前用户年龄段
        // 0 未认证
        // 1 成年
        // 2 未成年
        int AgeGroupOfCurrentUser();

        // 展示实名认证弹窗，如果游戏主界面增加实名认证按钮，用户点击后，可调用此接口显示实名认证界面
        // 用户可点击暂不认证
        void ShowRealNameView();

        // 展示实名认证界面
        // 用户可点击退出游戏
        void ShowRealNameViewWithForceExit();

        // 展示已在线时长界面，游戏初始化时调用
        void ShowAlertInfoController();

        // 展示查看详情界面
        // 展示防沉迷政策及规则
        void ShowCheckDetailInfoController();

        // 展示消费限制窗口
        // 成年人不受此限制
        void ShowCashLimitedController();

        // 获取当前用户剩余可玩时长，如果为-1，表示当前用户为成年人账号，将不受防沉迷限制,如果为大于0的数，返回的为当前用户的剩余可玩时长，单位秒
        int LeftTimeOfCurrentUser();

        //游戏退到后台时调用（iOS 不需要）
        void GameOnPause();

        //游戏恢复到前台时调用（iOS 不需要）
        void GameOnResume();

        // 暂停计时器
        void StopTimerInUnity();
        
        // 恢复计时器
        void ResumeTimerInUnity();
    }
}