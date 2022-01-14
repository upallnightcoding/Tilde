using Leo.render.behavior.action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde;
using Tilde.render.behavior;
using Tilde.render.behavior.action;
using Tilde.render.entity;
using Tilde.render.scene;

namespace Tilde
{
    class TestCase
    {
        public static SourceCode Case01()
        {
            SourceCode source = new SourceCode();

            source.Add("program test {");
            source.Add("    integer a = (1 + 2.2);");
            source.Add("    print \"Value a1:  \", a ;");
            source.Add("    a = 33 + 11;");
            source.Add("    print \"Value a2:  \", a ;");
            source.Add("}");

            return (source);
        }

        public static SourceCode Case02()
        {
            SourceCode source = new SourceCode();

            source.Add("program test {");
            source.Add("    integer a = (1 + 2.2), b = 4.67 / 2.0, c = 3.01;");
            source.Add("    float x = (1 + 2.2), y = 4.67 / 2.0, z = 3.01;");
            source.Add("    print 1 == 1, a == a;");
            source.Add("    print a, \" \", b, \" \", c ;");
            source.Add("    print x, \" \", y, \" \", z ;");
            source.Add("}");

            return (source);
        }

        public static Scene Case03()
        {
            Sprite s1 = new Sprite();
            s1.Add(new ActionMove(0.00005f, 0.0f, 0.0f));
            s1.Add(new ActionTurn(0.0f, 0.0f, 0.01f));

            Sprite s2 = new Sprite();
            s2.Add(new ActionMove(-0.00005f, 0.0f, 0.0f));

            Scene scene = new Scene();
            scene.Add(s1);
            scene.Add(s2);

            return (scene);
        }

        public static Scene Case04()
        {
            State state = new State("Move");
            state.Add(new ActionMove(-0.001f, 0.0f, 0.0f));

            FSM fsm = new FSM();
            fsm.Add(state);

            Sprite sprite = new Sprite();
            sprite.Set(fsm);

            Scene scene = new Scene();
            scene.Add(sprite);

            return (scene);
        }

        public static SourceCode Case05()
        {
            SourceCode source = new SourceCode();

            source.Add("program test {");
            source.Add("    print \"abc\" == \"abc\";");
            source.Add("    print \"xyz\" == \"abc\";");
            source.Add("    print 1 == 1, \" \",3.2 == 5.0;");
            source.Add("    print '9';");
            source.Add("    print '3', \" \", '1' == '1', \" \",3.2 == 5.0;");
            source.Add("}");

            return (source);
        }
    }
}
