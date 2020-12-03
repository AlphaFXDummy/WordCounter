import IWord from "./IWord"
export default interface IWordCounter {
    fileName: string,
    topTenWords: IWord[],
}
