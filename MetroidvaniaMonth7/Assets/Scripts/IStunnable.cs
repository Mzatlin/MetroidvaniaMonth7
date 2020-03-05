﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IStunnable
{
    event Action OnStun;
    bool IsStunned { get; set; }
    void HandleStun();
}