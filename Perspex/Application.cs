﻿// -----------------------------------------------------------------------
// <copyright file="Application.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex
{
    using Perspex.Input;
    using Perspex.Styling;
    using Splat;

    public class Application
    {
        private Styles styles;

        public Application()
        {
            Current = this;
            this.InputManager = new InputManager();
        }

        public static Application Current
        {
            get;
            private set;
        }

        public InputManager InputManager
        {
            get;
            private set;
        }

        public Styles Styles
        {
            get
            {
                if (this.styles == null)
                {
                    this.styles = new Styles();
                }

                return this.styles;
            }

            set
            {
                this.styles = value;
            }
        }

        public void RegisterServices()
        {
            Styler styler = new Styler();
            Locator.CurrentMutable.Register(() => this.InputManager, typeof(IInputManager));
            Locator.CurrentMutable.Register(() => styler, typeof(IStyler));
        }
    }
}
