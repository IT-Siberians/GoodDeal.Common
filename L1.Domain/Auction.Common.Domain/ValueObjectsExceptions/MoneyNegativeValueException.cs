﻿using System;

namespace Auction.Common.Domain.ValueObjectsExceptions;

/// <summary>
/// Исключение домена для отрицательного значения количества денег
/// </summary>
/// <param name="value">Значение количества денег</param>
internal class MoneyNegativeValueException(decimal value)
    : ArgumentException(
        $"The money value cannot be less than 0, the passed value is: {value}");
