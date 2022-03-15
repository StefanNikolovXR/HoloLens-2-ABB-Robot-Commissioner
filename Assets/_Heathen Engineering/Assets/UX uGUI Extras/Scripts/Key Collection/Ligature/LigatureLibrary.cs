using UnityEngine;
using System.Collections.Generic;
using System.Text;

namespace HeathenEngineering.UX.uGUIExtras
{
    [CreateAssetMenu(menuName = "UX/Ligature Library")]
    public class LigatureLibrary : ScriptableObject
    {
        /// <summary>
        /// List of ligatures to test for
        /// </summary>
        public List<LigatureReference> map = new List<LigatureReference>();
        
        public string ParseEnd(string value)
        {
            StringBuilder working = new StringBuilder(value);
            if (map != null)
            {
                foreach (LigatureReference lig in map)
                {
                    if (value.EndsWith(lig.Characters))
                    {
                        return value.Substring(0, value.Length - lig.Characters.Length) + lig.Ligature;
                    }
                    else
                        return value;
                }
            }

            return working.ToString();
        }

        public string ParseAll(string value)
        {
            StringBuilder working = new StringBuilder(value);
            if (map != null)
            {
                foreach (LigatureReference lig in map)
                {
                    working = working.Replace(lig.Characters, lig.Ligature);
                }
            }

            return working.ToString();
        }

        public void AddLigature(string input, string output)
        {
            if(!map.Exists(p => p.Characters == input))
            {
                map.Add(new LigatureReference(input, output));
            }
        }

        public void AddCommonLigatures()
        {
            if (map == null)
                map = new List<LigatureReference>();

            AddLigature("(C)", "©");
            AddLigature("(c)", "©");
            AddLigature("(SC)", "℗");
            AddLigature("(sc)", "℗");
            AddLigature("(Sc)", "℗");
            AddLigature("(sC)", "℗");
            AddLigature("(TM)", "™");
            AddLigature("(tm)", "™");
            AddLigature("(Tm)", "™");
            AddLigature("(tM)", "™");
            AddLigature("(RTM)", "®");
            AddLigature("(rtm)", "®");
            AddLigature("(rTm)", "®");
            AddLigature("(Rtm)", "®");
            AddLigature("(RTm)", "®");
            AddLigature("(RtM)", "®");
            AddLigature("(rTM)", "®");
            AddLigature("(rtM)", "®");
            AddLigature("(sm)", "℠");
            AddLigature("(SM)", "℠");
            AddLigature("(Sm)", "℠");
            AddLigature("(sM)", "℠");
            AddLigature("`a", "à");
            AddLigature("`A", "À");
            AddLigature("`e", "è");
            AddLigature("`E", "È");
            AddLigature("`i", "ì");
            AddLigature("`I", "Ì");
            AddLigature("`o", "ò");
            AddLigature("`O", "Ò");
            AddLigature("`u", "ù");
            AddLigature("`U", "Ù");
            AddLigature("(No)", "№");
            AddLigature("(#)", "№");
            AddLigature("(deg)", "°");
        }

        public void AddSupperScriptLigatures()
        {
            if (map == null)
                map = new List<LigatureReference>();

            AddLigature("^1", "¹");
            AddLigature("^2", "²");
            AddLigature("^3", "³");
            AddLigature("^4", "⁴");
            AddLigature("^5", "⁵");
            AddLigature("^6", "⁶");
            AddLigature("^7", "⁷");
            AddLigature("^8", "⁸");
            AddLigature("^9", "⁹");
            AddLigature("^0", "⁰");
            AddLigature("^+", "⁺");
            AddLigature("^-", "⁻");
            AddLigature("^=", "⁼");
            AddLigature("^(", "⁽");
            AddLigature("^)", "⁾");
            AddLigature("^a", "ᵃ");
            AddLigature("^b", "ᵇ");
            AddLigature("^c", "ᶜ");
            AddLigature("^d", "ᵈ");
            AddLigature("^e", "ᵉ");
            AddLigature("^f", "ᶠ");
            AddLigature("^g", "ᵍ");
            AddLigature("^h", "ʰ");
            AddLigature("^i", "ⁱ");
            AddLigature("^j", "ʲ");
            AddLigature("^k", "ᵏ");
            AddLigature("^l", "ˡ");
            AddLigature("^m", "ᵐ");
            AddLigature("^n", "ⁿ");
            AddLigature("^o", "ᵒ");
            AddLigature("^p", "ᵖ");
            AddLigature("^r", "ʳ");
            AddLigature("^s", "ˢ");
            AddLigature("^t", "ᵗ");
            AddLigature("^u", "ᵘ");
            AddLigature("^v", "ᵛ");
            AddLigature("^w", "ʷ");
            AddLigature("^x", "ˣ");
            AddLigature("^y", "ʸ");
            AddLigature("^z", "ᶻ");
            AddLigature("^A", "ᴬ");
            AddLigature("^B", "ᴮ");
            AddLigature("^D", "ᴰ");
            AddLigature("^E", "ᴱ");
            AddLigature("^G", "ᴳ");
            AddLigature("^H", "ᴴ");
            AddLigature("^I", "ᴵ");
            AddLigature("^J", "ᴶ");
            AddLigature("^K", "ᴷ");
            AddLigature("^L", "ᴸ");
            AddLigature("^M", "ᴹ");
            AddLigature("^N", "ᴺ");
            AddLigature("^O", "ᴼ");
            AddLigature("^P", "ᴾ");
            AddLigature("^R", "ᴿ");
            AddLigature("^T", "ᵀ");
            AddLigature("^U", "ᵁ");
            AddLigature("^V", "ⱽ");
            AddLigature("^W", "ᵂ");
        }

        public void AddFractionLigatures()
        {
            if (map == null)
                map = new List<LigatureReference>();

            AddLigature("1/4", "¼");
            AddLigature("2/4", "½");
            AddLigature("1/2", "½");
            AddLigature("3/4", "¾");
            AddLigature("1/10", "⅒");
            AddLigature("2/10", "⅕");
            AddLigature("4/10", "⅖");
            AddLigature("5/10", "½");
            AddLigature("6/10", "⅗");
            AddLigature("8/10", "⅘");
            AddLigature("1/3", "⅓");
            AddLigature("2/3", "⅔");
            AddLigature("1/5", "⅕");
            AddLigature("2/5", "⅖");
            AddLigature("3/5", "⅗");
            AddLigature("4/5", "⅘");
            AddLigature("1/6", "⅙");
            AddLigature("2/6", "⅓");
            AddLigature("3/6", "½");
            AddLigature("4/6", "⅔");
            AddLigature("5/6", "⅚");
            AddLigature("1/8", "⅛");
            AddLigature("2/8", "¼");
            AddLigature("3/8", "⅜");
            AddLigature("4/8", "½");
            AddLigature("5/8", "⅝");
            AddLigature("6/8", "¾");
            AddLigature("7/8", "⅞");
        }

        public void AddKatakanaLigatures()
        {
            if (map == null)
                map = new List<LigatureReference>();

            //A
            AddLigature("ア=", "ァ");
            AddLigature("ア-", "ァ");
            AddLigature("ka", "カ");
            AddLigature("sa", "サ");
            AddLigature("ta", "タ");
            AddLigature("na", "ナ");
            AddLigature("ha", "ハ");
            AddLigature("ma", "マ");
            AddLigature("ya", "ヤ");
            AddLigature("ヤ=", "ャ");
            AddLigature("ヤ-", "ャ");
            AddLigature("ra", "ラ");
            AddLigature("wa", "ワ");
            AddLigature("ga", "ガ");
            AddLigature("za", "ザ");
            AddLigature("da", "ダ");
            AddLigature("ba", "バ");
            AddLigature("pa", "パ");
            AddLigature("ンa", "ナ");
            AddLigature("a", "ア");
            //I
            AddLigature("イ=", "ィ");
            AddLigature("イ-", "ィ");
            AddLigature("ki", "キ");
            AddLigature("shi", "シ");
            AddLigature("chi", "チ");
            AddLigature("ni", "ニ");
            AddLigature("hi", "ヒ");
            AddLigature("mi", "ミ");
            AddLigature("ri", "リ");
            AddLigature("wi", "ヰ");
            AddLigature("gi", "ギ");
            AddLigature("ji", "ジ");
            AddLigature("di", "ヂ");
            AddLigature("ジ=", "ヂ");
            AddLigature("ジ-", "ヂ");
            AddLigature("bi", "ビ");
            AddLigature("pi", "ピ");
            AddLigature("i", "イ");
            //U
            AddLigature("ウ=", "ゥ");
            AddLigature("ウ-", "ゥ");
            AddLigature("ku", "ク");
            AddLigature("tス", "ツ");
            AddLigature("tsu", "ツ");
            AddLigature("su", "ス");
            AddLigature("nu", "ヌ");
            AddLigature("fu", "フ");
            AddLigature("mu", "ム");
            AddLigature("yu", "ユ");
            AddLigature("ユ=", "ュ");
            AddLigature("ユ-", "ュ");
            AddLigature("ru", "ル");
            AddLigature("gu", "グ");
            AddLigature("zu", "ズ");
            AddLigature("du", "ヅ");
            AddLigature("ズ=", "ヅ");
            AddLigature("ズ-", "ヅ");
            AddLigature("bu", "ブ");
            AddLigature("bu", "プ");
            AddLigature("u", "ウ");
            //E
            AddLigature("エ=", "ェ");
            AddLigature("エ-", "ェ");
            AddLigature("ke", "ケ");
            AddLigature("se", "セ");
            AddLigature("te", "テ");
            AddLigature("ne", "ネ");
            AddLigature("he", "ヘ");
            AddLigature("me", "メ");
            AddLigature("re", "レ");
            AddLigature("we", "ヱ");
            AddLigature("ge", "ゲ");
            AddLigature("ze", "ゼ");
            AddLigature("de", "デ");
            AddLigature("be", "ベ");
            AddLigature("pe", "ペ");
            AddLigature("e", "エ");
            //O
            AddLigature("オ=", "ォ");
            AddLigature("オ-", "ォ");
            AddLigature("ko", "コ");
            AddLigature("so", "ソ");
            AddLigature("to", "ト");
            AddLigature("no", "ノ");
            AddLigature("ho", "ホ");
            AddLigature("mo", "モ");
            AddLigature("yo", "ヨ");
            AddLigature("ヨ=", "ョ");
            AddLigature("ヨ-", "ョ");
            AddLigature("ro", "ロ");
            AddLigature("wo", "ヲ");
            AddLigature("go", "ゴ");
            AddLigature("zo", "ゾ");
            AddLigature("do", "ド");
            AddLigature("bo", "ボ");
            AddLigature("po", "ポ");
            AddLigature("o", "オ");
            //Alt
            AddLigature("v", "ヴ");
            AddLigature("n", "ン");
        }

        public void AddKoreanLigatures()
        {
            if (map == null)
                map = new List<LigatureReference>();

            string[] set1 = { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };
    string[] set2 = { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
    string[][] ligSet = {   new string[]{"가", "까", "나", "다", "따", "라", "마", "바", "빠", "사", "싸", "아", "자", "짜", "차", "카", "타", "파", "하"},
                                    new string[]{"개", "깨", "내", "대", "때", "래", "매", "배", "빼", "새", "쌔", "애", "재", "째", "채", "캐", "태", "패", "해"},
                                    new string[]{"갸", "꺄", "냐", "댜", "땨", "랴", "먀", "뱌", "뺘", "샤", "쌰", "야", "쟈", "쨔", "챠", "캬", "탸", "퍄", "햐"},
                                    new string[]{"걔", "꺠", "냬", "댸", "떄", "럐", "먜", "뱨", "뺴", "섀", "썌", "얘", "쟤", "쨰", "챼", "컈", "턔", "퍠", "햬"},
                                    new string[]{"거", "꺼", "너", "더", "떠", "러", "머", "버", "뻐", "서", "써", "어", "저", "쩌", "처", "커", "터", "퍼", "허"},
                                    new string[]{"게", "께", "네", "데", "떼", "레", "메", "베", "뻬", "세", "쎄", "에", "제", "쩨", "체", "케", "테", "페", "헤"},
                                    new string[]{"겨", "껴", "녀", "뎌", "뗘", "려", "며", "벼", "뼈", "셔", "쎠", "여", "져", "쪄", "쳐", "켜", "텨", "폐", "혀"},
                                    new string[]{"계", "꼐", "녜", "뎨", "뗴", "례", "몌", "볘", "뼤", "셰", "쎼", "예", "졔", "쪠", "쳬", "켸", "톄", "폐", "혜"},
                                    new string[]{"고", "	꼬", "노", "도", "또", "로", "모", "보", "뽀", "소", "쏘", "오", "조", "쪼", "초", "코", "토", "포", "호"},
                                    new string[]{"과", "꽈", "놔", "돠", "똬", "롸", "뫄", "봐", "뽜", "솨", "쏴", "와", "좌", "쫘", "촤", "콰", "톼", "퐈", "화"},
                                    new string[]{"괘", "꽤", "놰", "돼", "뙈", "뢔", "뫠", "봬", "뽸", "쇄", "쐐", "왜", "좨", "쫴", "쵀", "쾌", "퇘", "퐤", "홰"},
                                    new string[]{"괴", "꾀", "뇌", "되", "뙤", "뢰", "뫼", "뵈", "뾔", "쇠", "쐬", "외", "죄", "쬐", "최", "쾨", "퇴", "푀", "회"},
                                    new string[]{"교", "꾜", "뇨", "됴", "뚀", "료", "묘", "뵤", "뾰", "쇼", "쑈", "요", "죠", "쬬", "쵸", "쿄", "툐", "표", "효"},
                                    new string[]{"구", "꾸", "누", "두", "뚜", "루", "무", "부", "뿌", "수", "쑤", "우", "주", "쭈", "추", "쿠", "투", "푸", "후"},
                                    new string[]{"궈", "꿔", "눠", "둬", "뚸", "뤄", "뭐", "붜", "뿨", "숴", "쒀", "워", "줘", "쭤", "춰", "쿼", "퉈", "풔", "훠"},
                                    new string[]{"궤", "꿰", "눼", "뒈", "뛔", "뤠", "뭬", "붸", "쀄", "쉐", "쒜", "웨", "줴", "쮀", "췌", "퀘", "퉤", "풰", "훼"},
                                    new string[]{"귀", "뀌", "뉘", "뒤", "뛰", "뤼", "뮈", "뷔", "쀠", "쉬", "쒸", "위", "쥐", "쮜", "취", "퀴", "튀", "퓌", "휘"},
                                    new string[]{"규", "뀨", "뉴", "듀", "뜌", "류", "뮤", "뷰", "쀼", "슈", "쓔", "유", "쥬", "쮸", "츄", "큐", "튜", "퓨", "휴"},
                                    new string[]{"그", "끄", "느", "드", "뜨", "르", "므", "브", "쁘", "스", "쓰", "으", "즈", "쯔", "츠", "크", "트", "프", "흐"},
                                    new string[]{"긔", "끠", "늬", "듸", "띄", "릐", "믜", "븨", "쁴", "싀", "씌", "의", "즤", "쯰", "츼", "킈", "틔", "픠", "희"},
                                    new string[]{"기", "끼", "니", "디", "띠", "리", "미", "비", "삐", "시", "씨", "이", "지", "찌", "치", "키", "티", "피", "히" }};

            for (int i = 0; i<set2.Length; i++)
            {
                for (int ii = 0; ii<set1.Length; ii++)
                {
                    AddLigature(set2[i] + set1[ii], ligSet[ii][i]);
                }
            }
        }
    }
}