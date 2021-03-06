﻿using System;
using System.Reactive;

namespace NiceTry {
    public static class Try {
        public static ITry<Unit> To(Action work) {
            try {
                work();
                return new Success<Unit>(Unit.Default);
            }
            catch (Exception error) {
                return new Failure<Unit>(error);
            }
        }

        public static ITry<T> To<T>(Func<T> work) {
            try {
                var result = work();
                return new Success<T>(result);
            }
            catch (Exception error) {
                return new Failure<T>(error);
            }
        }

        public static ITry<T> Using<T, TDisposable>(Func<TDisposable> createDisposable,
                                                    Func<TDisposable, T> useDisposable) where TDisposable : IDisposable {
            return To(() => { using (var disposable = createDisposable()) return useDisposable(disposable); });
        }
    }
}