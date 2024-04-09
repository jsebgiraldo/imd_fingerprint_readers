using System;

namespace Utils
{
  /// <summary>
  /// Encapsulates a method that takes no parameters and does not return a value.
  /// </summary>
  public delegate void ActionHandler();

  /// <summary>
  /// Encapsulates a method that takes two parameters and does not return a value.
  /// </summary>
  /// <remarks>Work around for Action delegate present in .NET framework 3.5 and later.</remarks>
  /// <typeparam name="T1">The type of first argument.</typeparam>
  /// <typeparam name="T2">The type of second argument.</typeparam>
  /// <param name="arg1">The first argument.</param>
  /// <param name="arg2">The second argument.</param>
  public delegate void ActionHandler<T1, T2>(T1 arg1, T2 arg2);

  /// <summary>
  /// Encapsulates a method that takes three parameters and does not return a value.
  /// </summary>
  /// <remarks>Work around for Action delegate present in .NET framework 3.5 and later.</remarks>
  /// <typeparam name="T1">The type of first argument.</typeparam>
  /// <typeparam name="T2">The type of second argument.</typeparam>
  /// <typeparam name="T3">The type of third argument.</typeparam>
  /// <param name="arg1">The first argument.</param>
  /// <param name="arg2">The second argument.</param>
  /// <param name="arg3">The third argument.</param>
  public delegate void ActionHandler<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
}
