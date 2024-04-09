using System;

namespace Utils
{
  /// <summary>
  /// Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.
  /// </summary>
  /// <typeparam name="T">value type</typeparam>
  /// <typeparam name="TResult">The type of the result.</typeparam>
  /// <param name="arg">The argument.</param>
  /// <returns>value of type expecified in tresult</returns>
  public delegate TResult FuncHandler<T, TResult>(T arg);

  /// <summary>
  /// Encapsulates a method that has two parameters and returns a value of the type specified by the TResult parameter.
  /// </summary>
  /// <typeparam name="T1">The type of the first parameter.</typeparam>
  /// <typeparam name="T2">The type of the second parameter.</typeparam>
  /// <typeparam name="TResult">The type of the result.</typeparam>
  /// <param name="arg1">The first argument.</param>
  /// <param name="arg2">The second argument.</param>
  /// <returns>The value of type specified in TResult.</returns>
  public delegate TResult FuncHandler<T1, T2, TResult>(T1 arg1, T2 arg2);

  /// <summary>
  /// Encapsulates a method that has three parameters and returns a value of the type specified by the TResult parameter.
  /// </summary>
  /// <typeparam name="T1">The type of the first parameter.</typeparam>
  /// <typeparam name="T2">The type of the second parameter.</typeparam>
  /// <typeparam name="T3">The type of the third parameter.</typeparam>
  /// <typeparam name="TResult">The type of the result.</typeparam>
  /// <param name="arg1">The first argument.</param>
  /// <param name="arg2">The second argument.</param>
  /// <param name="arg3">The third argument.</param>
  /// <returns>The value of type specified in TResult.</returns>
  public delegate TResult FuncHandler<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);
}
