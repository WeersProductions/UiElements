﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FancyButton : Button
{
    private RectTransform _rect;

    protected override void Awake()
    {
        base.Awake();

        _rect = GetComponent<RectTransform>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        DOTween.To(value => _rect.localScale = new Vector3(value, value, value), 0, 1, 0.6f).SetEase(Ease.OutElastic);
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        float duration = 0.7f;
        if (instant)
        {
            duration = 0;
        }

        switch (state)
        {
            case SelectionState.Normal:
                _rect.DOScale(Vector3.one, duration).SetEase(Ease.OutElastic);
                break;
            case SelectionState.Highlighted:
                _rect.DOScale(new Vector3(1.08f, 1.08f, 1.08f), duration).SetEase(Ease.OutElastic);
                break;
            case SelectionState.Pressed:
                _rect.DOPunchScale(new Vector3(-0.1f, -0.1f, -0.1f), duration, 5, 0.5f).SetEase(Ease.OutElastic);
                break;
            case SelectionState.Disabled:
                _rect.DOScale(Vector3.one, duration);
                break;
            default:
                throw new ArgumentOutOfRangeException("state", state, null);
        }
    }
}